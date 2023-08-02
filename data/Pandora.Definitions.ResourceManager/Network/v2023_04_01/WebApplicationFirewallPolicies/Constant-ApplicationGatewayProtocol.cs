using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayProtocolConstant
{
    [Description("Http")]
    HTTP,

    [Description("Https")]
    HTTPS,

    [Description("Tcp")]
    Tcp,

    [Description("Tls")]
    Tls,
}
