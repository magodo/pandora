using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.GraphAPICompute;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceSizeConstant
{
    [Description("Cosmos.D8s")]
    CosmosPointDEights,

    [Description("Cosmos.D4s")]
    CosmosPointDFours,

    [Description("Cosmos.D16s")]
    CosmosPointDOneSixs,
}
