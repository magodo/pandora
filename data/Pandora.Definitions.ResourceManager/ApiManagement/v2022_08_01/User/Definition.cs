using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.User;

internal class Definition : ResourceDefinition
{
    public string Name => "User";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetEntityTagOperation(),
        new ListByServiceOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AppTypeConstant),
        typeof(ConfirmationConstant),
        typeof(GroupTypeConstant),
        typeof(UserStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GroupContractPropertiesModel),
        typeof(UserContractModel),
        typeof(UserContractPropertiesModel),
        typeof(UserCreateParameterPropertiesModel),
        typeof(UserCreateParametersModel),
        typeof(UserIdentityContractModel),
        typeof(UserUpdateParametersModel),
        typeof(UserUpdateParametersPropertiesModel),
    };
}
