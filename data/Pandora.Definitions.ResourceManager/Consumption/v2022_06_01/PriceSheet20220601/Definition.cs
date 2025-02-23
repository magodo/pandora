using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2022_06_01.PriceSheet20220601;

internal class Definition : ResourceDefinition
{
    public string Name => "PriceSheet20220601";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PriceSheetsGetOperation(),
        new PriceSheetsGetByBillingPeriodOperation(),
    };
}
