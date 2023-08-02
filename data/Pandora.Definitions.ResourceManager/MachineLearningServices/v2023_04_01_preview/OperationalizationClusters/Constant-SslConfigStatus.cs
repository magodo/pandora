using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.OperationalizationClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SslConfigStatusConstant
{
    [Description("Auto")]
    Auto,

    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
