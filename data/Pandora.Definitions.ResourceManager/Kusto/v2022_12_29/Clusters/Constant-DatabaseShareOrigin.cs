using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_12_29.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatabaseShareOriginConstant
{
    [Description("DataShare")]
    DataShare,

    [Description("Direct")]
    Direct,

    [Description("Other")]
    Other,
}
