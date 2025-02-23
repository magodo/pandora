using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.SingleSignOn;

internal class SingleSignOnConfigurationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logz/monitors/{monitorName}/singleSignOnConfigurations/{singleSignOnConfigurationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftLogz", "Microsoft.Logz"),
        ResourceIDSegment.Static("staticMonitors", "monitors"),
        ResourceIDSegment.UserSpecified("monitorName"),
        ResourceIDSegment.Static("staticSingleSignOnConfigurations", "singleSignOnConfigurations"),
        ResourceIDSegment.UserSpecified("singleSignOnConfigurationName"),
    };
}
