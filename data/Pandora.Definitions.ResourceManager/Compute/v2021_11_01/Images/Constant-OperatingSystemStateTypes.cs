using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.Images;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatingSystemStateTypesConstant
{
    [Description("Generalized")]
    Generalized,

    [Description("Specialized")]
    Specialized,
}
