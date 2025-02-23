using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.ManagementGroups;

internal class GetDescendantsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ManagementGroupId();

    public override Type NestedItemType() => typeof(DescendantInfoModel);

    public override Type? OptionsObject() => typeof(GetDescendantsOperation.GetDescendantsOptions);

    public override string? UriSuffix() => "/descendants";

    internal class GetDescendantsOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
