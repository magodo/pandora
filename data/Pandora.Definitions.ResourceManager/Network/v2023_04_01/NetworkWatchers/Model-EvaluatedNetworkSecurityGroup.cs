using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.NetworkWatchers;


internal class EvaluatedNetworkSecurityGroupModel
{
    [JsonPropertyName("appliedTo")]
    public string? AppliedTo { get; set; }

    [JsonPropertyName("matchedRule")]
    public MatchedRuleModel? MatchedRule { get; set; }

    [JsonPropertyName("networkSecurityGroupId")]
    public string? NetworkSecurityGroupId { get; set; }

    [JsonPropertyName("rulesEvaluationResult")]
    public List<NetworkSecurityRulesEvaluationResultModel>? RulesEvaluationResult { get; set; }
}
