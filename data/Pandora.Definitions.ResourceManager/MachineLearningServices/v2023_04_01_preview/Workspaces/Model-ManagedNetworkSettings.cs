using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Workspaces;


internal class ManagedNetworkSettingsModel
{
    [JsonPropertyName("isolationMode")]
    public IsolationModeConstant? IsolationMode { get; set; }

    [JsonPropertyName("networkId")]
    public string? NetworkId { get; set; }

    [JsonPropertyName("outboundRules")]
    public Dictionary<string, OutboundRuleModel>? OutboundRules { get; set; }

    [JsonPropertyName("status")]
    public ManagedNetworkProvisionStatusModel? Status { get; set; }
}
