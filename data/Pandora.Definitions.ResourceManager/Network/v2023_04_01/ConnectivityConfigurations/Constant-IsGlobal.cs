using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.ConnectivityConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IsGlobalConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
