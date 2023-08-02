using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayRequestRoutingRuleTypeConstant
{
    [Description("Basic")]
    Basic,

    [Description("PathBasedRouting")]
    PathBasedRouting,
}
