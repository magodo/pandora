using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.DataContainer;

internal class ListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new WorkspaceId();

    public override Type NestedItemType() => typeof(DataContainerResourceModel);

    public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

    public override string? UriSuffix() => "/data";

    internal class ListOptions
    {
        [QueryStringName("listViewType")]
        [Optional]
        public ListViewTypeConstant ListViewType { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }
    }
}
