using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.Diagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngressClientCertificateModeConstant
{
    [Description("accept")]
    Accept,

    [Description("ignore")]
    Ignore,

    [Description("require")]
    Require,
}
