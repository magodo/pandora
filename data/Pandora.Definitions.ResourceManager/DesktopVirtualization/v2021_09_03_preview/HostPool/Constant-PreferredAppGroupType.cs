using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.HostPool;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PreferredAppGroupTypeConstant
{
    [Description("Desktop")]
    Desktop,

    [Description("None")]
    None,

    [Description("RailApplications")]
    RailApplications,
}
