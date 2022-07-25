using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.CapacityReservationGroups;


internal class CapacityReservationGroupUpdateModel
{
    [JsonPropertyName("properties")]
    public CapacityReservationGroupPropertiesModel? Properties { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
