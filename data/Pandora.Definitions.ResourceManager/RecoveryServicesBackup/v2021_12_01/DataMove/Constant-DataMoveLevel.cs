using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.DataMove;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataMoveLevelConstant
{
    [Description("Container")]
    Container,

    [Description("Invalid")]
    Invalid,

    [Description("Vault")]
    Vault,
}
