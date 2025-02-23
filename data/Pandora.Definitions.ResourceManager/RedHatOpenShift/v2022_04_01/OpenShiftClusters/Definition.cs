using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedHatOpenShift.v2022_04_01.OpenShiftClusters;

internal class Definition : ResourceDefinition
{
    public string Name => "OpenShiftClusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAdminCredentialsOperation(),
        new ListByResourceGroupOperation(),
        new ListCredentialsOperation(),
        new UpdateOperation(),
    };
}
