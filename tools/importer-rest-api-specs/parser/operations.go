package parser

import (
	"fmt"
	"log"
	"net/http"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type operationsParser struct {
	operations            []parsedOperation
	resourceUriToMetaData map[string]resourceUriMetadata
	swaggerDefinition     *SwaggerDefinition
}

func (d *SwaggerDefinition) parseOperationsWithinTag(tag *string, resourceUriToMetaData map[string]resourceUriMetadata, found parseResult) (*map[string]models.OperationDetails, *parseResult, error) {
	operations := make(map[string]models.OperationDetails, 0)
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(found)

	parser := operationsParser{
		resourceUriToMetaData: resourceUriToMetaData,
		swaggerDefinition:     d,
	}

	// first find the operations then pull out everything we can
	operationsForThisTag := d.findOperationsMatchingTag(tag)
	for _, operation := range *operationsForThisTag {
		if d.debugLog {
			log.Printf("[DEBUG] Operation - %s %q..", operation.httpMethod, operation.uri)
		}

		if operationShouldBeIgnored(operation.uri) {
			if d.debugLog {
				log.Printf("[DEBUG] operation should be ignored - skipping..")
			}
			continue
		}

		parsedOperation, nestedResult, err := parser.parseOperation(operation)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing %s operation %q: %+v", operation.httpMethod, operation.uri, err)
		}
		if nestedResult != nil {
			result.append(*nestedResult)
		}

		if existing, hasExisting := operations[operation.name]; hasExisting {
			return nil, nil, fmt.Errorf("conflicting operations with the Name %q - first %q %q - second %q %q", operation.name, existing.Method, existing.Uri, parsedOperation.Method, parsedOperation.Uri)
		}

		if parsedOperation == nil {
			continue
		}

		operations[operation.name] = *parsedOperation
	}

	return &operations, &result, nil
}

func (p operationsParser) parseOperation(operation parsedOperation) (*models.OperationDetails, *parseResult, error) {
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	normalizedUri, err := p.normalizedUriForOperation(operation)
	if err != nil {
		return nil, nil, fmt.Errorf("determining the normalized uri: %+v", err)
	}
	contentType := p.determineContentType(operation)
	expectedStatusCodes := p.expectedStatusCodesForOperation(operation)
	paginationField := p.fieldContainingPaginationDetailsForOperation(operation)
	requestObject, nestedResult, err := p.requestObjectForOperation(operation, result)
	if err != nil {
		return nil, nil, fmt.Errorf("determining request operation for %q (method %q / uri %q): %+v", operation.name, operation.httpMethod, *normalizedUri, err)
	}
	if nestedResult != nil {
		result.append(*nestedResult)
	}
	isAListOperation := p.isListOperation(operation)
	responseResult, nestedResult, err := p.responseObjectForOperation(operation, result)
	if err != nil {
		return nil, nil, fmt.Errorf("determining response operation for %q (method %q / uri %q): %+v", operation.name, operation.httpMethod, *normalizedUri, err)
	}
	if nestedResult != nil {
		result.append(*nestedResult)
	}
	if paginationField == nil && responseResult.paginationFieldName != nil {
		paginationField = responseResult.paginationFieldName
	}
	longRunning := p.operationIsLongRunning(operation)

	options, nestedResult, err := p.optionsForOperation(operation)
	if err != nil {
		return nil, nil, fmt.Errorf("building options for operation %q: %+v", operation.name, err)
	}
	if nestedResult != nil {
		result.append(*nestedResult)
	}

	resourceId := p.resourceUriToMetaData[*normalizedUri]

	operationData := models.OperationDetails{
		ApiVersion:                       nil, // TODO: investigate 'security' and other packages which use this
		ContentType:                      contentType,
		ExpectedStatusCodes:              expectedStatusCodes,
		FieldContainingPaginationDetails: paginationField,
		IsListOperation:                  isAListOperation,
		LongRunning:                      longRunning,
		Method:                           strings.ToUpper(operation.httpMethod),
		Options:                          *options,
		RequestObject:                    requestObject,
		ResourceIdName:                   resourceId.resourceIdName,
		ResponseObject:                   responseResult.objectDefinition,
		Uri:                              *normalizedUri,
		UriSuffix:                        resourceId.uriSuffix,
	}

	if p.operationShouldBeIgnored(operationData) {
		return nil, nil, nil
	}

	return &operationData, &result, nil
}

func (p operationsParser) determineObjectDefinitionForOption(input spec.Parameter) (*models.ObjectDefinition, error) {
	if strings.EqualFold(input.Type, "array") {
		// https://github.com/Azure/azure-rest-api-specs/blob/1b0ed8edd58bb7c9ade9a27430759527bd4eec8e/specification/trafficmanager/resource-manager/Microsoft.Network/stable/2018-03-01/trafficmanager.json#L735-L738
		if input.Items == nil {
			return nil, fmt.Errorf("an array/csv option type was specified with no items")
		}

		innerType, err := p.determineObjectDefinitionForOptionRaw(input.Items.Type, input.Items.CollectionFormat, input.Items.Format)
		if err != nil {
			return nil, fmt.Errorf("determining nested object definition for option: %+v", err)
		}

		if strings.EqualFold(input.CollectionFormat, "csv") {
			return &models.ObjectDefinition{
				Type:       models.ObjectDefinitionCsv,
				NestedItem: innerType,
			}, nil
		}

		return &models.ObjectDefinition{
			Type:       models.ObjectDefinitionList,
			NestedItem: innerType,
		}, nil
	}

	return p.determineObjectDefinitionForOptionRaw(input.Type, input.CollectionFormat, input.Format)
}

func (p operationsParser) determineObjectDefinitionForOptionRaw(paramType string, collectionFormat string, format string) (*models.ObjectDefinition, error) {
	switch strings.ToLower(paramType) {
	case "array":
		{
			if strings.EqualFold(collectionFormat, "csv") {
				return nil, fmt.Errorf("cannot contain a csv")
			}

			return nil, fmt.Errorf("cannot contain an array")
		}

	case "boolean":
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionBoolean,
		}, nil

	case "integer":
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionInteger,
		}, nil

	case "number":
		{
			if strings.EqualFold(format, "double") {
				return &models.ObjectDefinition{
					Type: models.ObjectDefinitionFloat,
				}, nil
			}
		}

	case "string":
		return &models.ObjectDefinition{
			Type: models.ObjectDefinitionString,
		}, nil
	}
	return nil, fmt.Errorf("unsupported field type %q", paramType)
}

func (p operationsParser) determineContentType(operation parsedOperation) string {
	contentType := "application/json"

	if strings.EqualFold(operation.httpMethod, "HEAD") || strings.EqualFold(operation.httpMethod, "GET") {
		if len(operation.operation.Consumes) > 0 {
			contentType = operation.operation.Consumes[0]
		}
	} else {
		if len(operation.operation.Produces) > 0 {
			contentType = operation.operation.Produces[0]
		}
	}

	return contentType
}

func (p operationsParser) expectedStatusCodesForOperation(input parsedOperation) []int {
	statusCodes := make([]int, 0)

	for statusCode := range input.operation.Responses.StatusCodeResponses {
		// sanity checking
		if p.operationIsASuccess(statusCode) {
			statusCodes = append(statusCodes, statusCode)
		}
	}

	return statusCodes
}

func (p operationsParser) fieldContainingPaginationDetailsForOperation(input parsedOperation) *string {
	if raw, ok := input.operation.VendorExtensible.Extensions["x-ms-pageable"]; ok {
		val, ok := raw.(map[string]interface{})
		if ok {
			for k, v := range val {
				// this can be 'null' in the swagger
				if v == nil {
					continue
				}
				if strings.EqualFold("nextLinkName", k) {
					str := v.(string)
					return &str
				}
			}
		}
	}

	return nil
}

func (p operationsParser) isListOperation(input parsedOperation) bool {
	paginationField := p.fieldContainingPaginationDetailsForOperation(input)
	if paginationField != nil {
		return true
	}

	// otherwise if we have a parameter of `$skiptoken` in the query, we assume that it is
	for _, parameter := range input.operation.Parameters {
		if strings.EqualFold(parameter.Name, "$skipToken") {
			return true
		}
	}

	return false
}

func (p operationsParser) operationIsLongRunning(input parsedOperation) bool {
	// Some Swaggers have the following defined on an Operation:
	//   > "x-ms-long-running-operation": true,
	//   > "x-ms-long-running-operation-options": {
	//   >   "final-state-via": "azure-async-operation"
	//   > }
	// Whilst these _could_ be useful at some point we can likely ignore them for
	// the moment since the convention is either `Location` or `Azure-AsyncOperation`
	val, exists := input.operation.Extensions.GetBool("x-ms-long-running-operation")
	if !exists {
		return false
	}

	return val
}

func (p operationsParser) optionsForOperation(input parsedOperation) (*map[string]models.OperationOption, *parseResult, error) {
	output := make(map[string]models.OperationOption)
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
	}

	for _, param := range input.operation.Parameters {
		// these are (currently) handled elsewhere, so we're good for now
		if strings.EqualFold(param.Name, "$skipToken") {
			// NOTE: we may also need to do the odata ones, media has an example
			continue
		}

		// handled elsewhere
		if strings.EqualFold(param.Name, "api-version") {
			continue
		}

		// TODO: support parsing/generating these from Headers too
		if strings.EqualFold(param.In, "query") {
			name := cleanup.NormalizeName(param.Name)

			option := models.OperationOption{
				QueryStringName: param.Name,
				Required:        param.Required,
			}

			// looks like these can be dates etc too
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "name": "reportedEndTime",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "in": "query",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "required": true,
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "type": "string",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json:            "format": "date-time",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "description": "The end of the time range to retrieve data for."
			objectDefinition, err := p.determineObjectDefinitionForOption(param)
			if err != nil {
				return nil, nil, fmt.Errorf("determining field type for operation: %+v", err)
			}
			option.ObjectDefinition = objectDefinition

			if param.Enum != nil {
				types := []string{
					param.Type,
				}
				constant, err := mapConstant(types, param.Name, param.Enum, param.Extensions)
				if err != nil {
					return nil, nil, fmt.Errorf("mapping %q: %+v", param.Name, err)
				}
				result.constants[constant.name] = constant.details

				option.ObjectDefinition = &models.ObjectDefinition{
					Type:          models.ObjectDefinitionReference,
					ReferenceName: &constant.name,
				}
			}

			output[name] = option
		}
	}

	return &output, &result, nil
}

func (p operationsParser) operationShouldBeIgnored(input models.OperationDetails) bool {
	// Some HTTP Operations don't make sense for us to expose at this time, for example
	// a GET request which returns no content. They may at some point in the future but
	// for now there's not much point
	//
	// Example: the 'GetSubscriptionOperationWithAsyncResponse' in Web, which returns the
	// result of a LRO - but in our case that's handled elsewhere so we don't need it
	if strings.EqualFold(input.Method, "GET") {
		if len(input.ExpectedStatusCodes) == 1 && input.ExpectedStatusCodes[0] == http.StatusNoContent && input.ResponseObject == nil {
			return true
		}
	}

	return false
}

func (p operationsParser) normalizedUriForOperation(input parsedOperation) (*string, error) {
	for key := range p.resourceUriToMetaData {
		if strings.EqualFold(key, input.uri) {
			return &key, nil
		}
	}

	return nil, fmt.Errorf("%q was not found in the normalized uri list", input.uri)
}

func (p operationsParser) requestObjectForOperation(input parsedOperation, known parseResult) (*models.ObjectDefinition, *parseResult, error) {
	// all we should parse out is the top level object - nothing more.

	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := p.swaggerDefinition.swaggerSpecWithReferences.OperationForName(input.operation.ID)
	if !found {
		return nil, nil, nil
	}

	for _, param := range unexpandedOperation.Parameters {
		if strings.EqualFold(param.In, "body") {
			objectDefinition, result, err := p.swaggerDefinition.parseObjectDefinition(param.Schema.Title, param.Schema.Title, param.Schema, known)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing request object for parameter %q: %+v", param.Name, err)
			}
			if objectDefinition != nil {
				return objectDefinition, result, nil
			}
		}
	}

	return nil, nil, nil
}

type operationResponseObjectResult struct {
	objectDefinition    *models.ObjectDefinition
	paginationFieldName *string
}

func (p operationsParser) operationIsASuccess(statusCode int) bool {
	return statusCode >= 200 && statusCode < 300
}

func (p operationsParser) responseObjectForOperation(input parsedOperation, known parseResult) (*operationResponseObjectResult, *parseResult, error) {
	output := operationResponseObjectResult{}
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	result.append(known)

	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := p.swaggerDefinition.swaggerSpecWithReferences.OperationForName(input.operation.ID)
	if !found {
		return nil, nil, fmt.Errorf("couldn't find Operation ID %q in the unexpanded Swagger spec", input.operation.ID)
	}

	for statusCode, details := range unexpandedOperation.Responses.StatusCodeResponses {
		if p.operationIsASuccess(statusCode) {
			if details.ResponseProps.Schema == nil {
				continue
			}

			objectDefinition, nestedResult, err := p.swaggerDefinition.parseObjectDefinition(details.ResponseProps.Schema.Title, details.ResponseProps.Schema.Title, details.ResponseProps.Schema, result)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing response object from status code %d: %+v", statusCode, err)
			}
			output.objectDefinition = objectDefinition
			result.append(*nestedResult)
		}
	}

	return &output, &result, nil
}

type parsedOperation struct {
	name       string
	uri        string
	httpMethod string
	operation  *spec.Operation
}

func (d *SwaggerDefinition) findOperationsMatchingTag(tag *string) *[]parsedOperation {
	result := make([]parsedOperation, 0)

	for httpMethod, operation := range d.swaggerSpecExpanded.Operations() {
		for uri, operationDetails := range operation {
			if !operationMatchesTag(operationDetails, tag) {
				continue
			}

			operationName := normalizeOperationName(operationDetails.ID, tag)
			result = append(result, parsedOperation{
				name:       operationName,
				uri:        uri,
				httpMethod: httpMethod,
				operation:  operationDetails,
			})
		}
	}

	return &result
}
