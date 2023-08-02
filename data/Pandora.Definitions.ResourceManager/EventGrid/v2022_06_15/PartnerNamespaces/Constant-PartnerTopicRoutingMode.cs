using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.PartnerNamespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PartnerTopicRoutingModeConstant
{
    [Description("ChannelNameHeader")]
    ChannelNameHeader,

    [Description("SourceEventAttribute")]
    SourceEventAttribute,
}
