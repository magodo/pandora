using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_12_01.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ArmServerKeyTypeConstant
{
    [Description("AzureKeyVault")]
    AzureKeyVault,

    [Description("SystemAssigned")]
    SystemAssigned,
}
