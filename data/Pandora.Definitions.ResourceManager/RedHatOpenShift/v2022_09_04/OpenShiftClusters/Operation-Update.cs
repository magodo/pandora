using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedHatOpenShift.v2022_09_04.OpenShiftClusters;

internal class UpdateOperation : Operations.PatchOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(OpenShiftClusterUpdateModel);

    public override ResourceID? ResourceId() => new ProviderOpenShiftClusterId();

    public override Type? ResponseObject() => typeof(OpenShiftClusterModel);


}
