using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_12_29.ClusterPrincipalAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterPrincipalRoleConstant
{
    [Description("AllDatabasesAdmin")]
    AllDatabasesAdmin,

    [Description("AllDatabasesViewer")]
    AllDatabasesViewer,
}
