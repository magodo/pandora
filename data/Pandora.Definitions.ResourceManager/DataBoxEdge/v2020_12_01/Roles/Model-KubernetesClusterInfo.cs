using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Roles;


internal class KubernetesClusterInfoModel
{
    [JsonPropertyName("etcdInfo")]
    public EtcdInfoModel? EtcdInfo { get; set; }

    [JsonPropertyName("nodes")]
    public List<NodeInfoModel>? Nodes { get; set; }

    [JsonPropertyName("version")]
    [Required]
    public string Version { get; set; }
}
