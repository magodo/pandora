using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.OperationalizationClusters;

internal class ComputeListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new WorkspaceId();

    public override Type NestedItemType() => typeof(ComputeResourceModel);

    public override Type? OptionsObject() => typeof(ComputeListOperation.ComputeListOptions);

    public override string? UriSuffix() => "/computes";

    internal class ComputeListOptions
    {
        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }
    }
}
