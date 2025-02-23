using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.StreamingJobs;

internal class Definition : ResourceDefinition
{
    public string Name => "StreamingJobs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrReplaceOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ScaleOperation(),
        new SkuListOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
}
