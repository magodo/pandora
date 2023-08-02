using Pandora.Definitions.Interfaces;
using System.Collections.Generic;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService;

public partial class Service : ServiceDefinition
{
    public string Name => "ContainerService";
    public string? ResourceProvider => "Microsoft.ContainerService";
    public string? TerraformPackageName => "containers";

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
        new Terraform.KubernetesClusterTrustedAccessRoleBindingResource(),
        new Terraform.KubernetesFleetManagerResource(),
    };
}
