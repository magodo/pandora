using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ManagedCertificates;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedCertificates";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CertificateProvisioningStateConstant),
        typeof(ManagedCertificateDomainControlValidationConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedCertificateModel),
        typeof(ManagedCertificatePatchModel),
        typeof(ManagedCertificatePropertiesModel),
    };
}
