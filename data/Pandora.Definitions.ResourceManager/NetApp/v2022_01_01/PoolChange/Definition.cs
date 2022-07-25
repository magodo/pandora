using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_01_01.PoolChange;

internal class Definition : ResourceDefinition
{
    public string Name => "PoolChange";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new VolumesPoolChangeOperation(),
    };
}
