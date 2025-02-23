using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_01.AgentPools;

internal class GetUpgradeProfileOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new AgentPoolId();

    public override Type? ResponseObject() => typeof(AgentPoolUpgradeProfileModel);

    public override string? UriSuffix() => "/upgradeProfiles/default";


}
