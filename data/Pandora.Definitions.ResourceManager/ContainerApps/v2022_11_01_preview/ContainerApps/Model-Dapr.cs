using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ContainerApps;


internal class DaprModel
{
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appPort")]
    public int? AppPort { get; set; }

    [JsonPropertyName("appProtocol")]
    public AppProtocolConstant? AppProtocol { get; set; }

    [JsonPropertyName("enableApiLogging")]
    public bool? EnableApiLogging { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("httpMaxRequestSize")]
    public int? HTTPMaxRequestSize { get; set; }

    [JsonPropertyName("httpReadBufferSize")]
    public int? HTTPReadBufferSize { get; set; }

    [JsonPropertyName("logLevel")]
    public LogLevelConstant? LogLevel { get; set; }
}
