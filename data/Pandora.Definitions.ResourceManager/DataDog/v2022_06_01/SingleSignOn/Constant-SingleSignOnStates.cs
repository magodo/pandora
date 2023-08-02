using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataDog.v2022_06_01.SingleSignOn;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SingleSignOnStatesConstant
{
    [Description("Disable")]
    Disable,

    [Description("Enable")]
    Enable,

    [Description("Existing")]
    Existing,

    [Description("Initial")]
    Initial,
}
