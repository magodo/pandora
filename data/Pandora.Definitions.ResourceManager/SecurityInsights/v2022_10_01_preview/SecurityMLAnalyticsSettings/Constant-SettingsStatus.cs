using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.SecurityMLAnalyticsSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingsStatusConstant
{
    [Description("Flighting")]
    Flighting,

    [Description("Production")]
    Production,
}
