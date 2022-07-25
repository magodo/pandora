using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;


internal class VirtualMachineScaleSetNetworkProfileModel
{
    [JsonPropertyName("healthProbe")]
    public ApiEntityReferenceModel? HealthProbe { get; set; }

    [JsonPropertyName("networkApiVersion")]
    public NetworkApiVersionConstant? NetworkApiVersion { get; set; }

    [JsonPropertyName("networkInterfaceConfigurations")]
    public List<VirtualMachineScaleSetNetworkConfigurationModel>? NetworkInterfaceConfigurations { get; set; }
}
