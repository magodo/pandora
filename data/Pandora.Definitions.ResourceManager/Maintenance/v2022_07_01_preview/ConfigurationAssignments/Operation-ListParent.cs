using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2022_07_01_preview.ConfigurationAssignments;

internal class ListParentOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ResourceGroupProviderId();

    public override Type? ResponseObject() => typeof(ListConfigurationAssignmentsResultModel);

    public override string? UriSuffix() => "/providers/Microsoft.Maintenance/configurationAssignments";


}
