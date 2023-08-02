using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.MachineLearningComputes;

internal class Definition : ResourceDefinition
{
    public string Name => "MachineLearningComputes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ComputeCreateOrUpdateOperation(),
        new ComputeDeleteOperation(),
        new ComputeGetOperation(),
        new ComputeListOperation(),
        new ComputeListKeysOperation(),
        new ComputeListNodesOperation(),
        new ComputeRestartOperation(),
        new ComputeStartOperation(),
        new ComputeStopOperation(),
        new ComputeUpdateOperation(),
        new ComputeUpdateCustomServicesOperation(),
        new ComputeUpdateIdleShutdownSettingOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AllocationStateConstant),
        typeof(ApplicationSharingPolicyConstant),
        typeof(AutosaveConstant),
        typeof(CachingConstant),
        typeof(ClusterPurposeConstant),
        typeof(ComputeInstanceAuthorizationTypeConstant),
        typeof(ComputeInstanceStateConstant),
        typeof(ComputePowerActionConstant),
        typeof(ComputeTypeConstant),
        typeof(EnvironmentVariableTypeConstant),
        typeof(ImageTypeConstant),
        typeof(LoadBalancerTypeConstant),
        typeof(MlflowAutologgerConstant),
        typeof(MountActionConstant),
        typeof(MountStateConstant),
        typeof(NetworkConstant),
        typeof(NodeStateConstant),
        typeof(OperationNameConstant),
        typeof(OperationStatusConstant),
        typeof(OperationTriggerConstant),
        typeof(OsTypeConstant),
        typeof(ProtocolConstant),
        typeof(ProvisioningStateConstant),
        typeof(ProvisioningStatusConstant),
        typeof(RecurrenceFrequencyConstant),
        typeof(RemoteLoginPortPublicAccessConstant),
        typeof(ScheduleProvisioningStateConstant),
        typeof(ScheduleStatusConstant),
        typeof(SkuTierConstant),
        typeof(SourceTypeConstant),
        typeof(SshPublicAccessConstant),
        typeof(SslConfigStatusConstant),
        typeof(StorageAccountTypeConstant),
        typeof(TriggerTypeConstant),
        typeof(UnderlyingResourceActionConstant),
        typeof(VMPriorityConstant),
        typeof(VolumeDefinitionTypeConstant),
        typeof(WeekDayConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AKSModel),
        typeof(AKSSchemaPropertiesModel),
        typeof(AksComputeSecretsModel),
        typeof(AksNetworkingConfigurationModel),
        typeof(AmlComputeModel),
        typeof(AmlComputeNodeInformationModel),
        typeof(AmlComputeNodesInformationModel),
        typeof(AmlComputePropertiesModel),
        typeof(AssignedUserModel),
        typeof(AutoPausePropertiesModel),
        typeof(AutoScalePropertiesModel),
        typeof(BindOptionsModel),
        typeof(ClusterUpdateParametersModel),
        typeof(ClusterUpdatePropertiesModel),
        typeof(ComputeModel),
        typeof(ComputeInstanceModel),
        typeof(ComputeInstanceApplicationModel),
        typeof(ComputeInstanceAutologgerSettingsModel),
        typeof(ComputeInstanceConnectivityEndpointsModel),
        typeof(ComputeInstanceContainerModel),
        typeof(ComputeInstanceCreatedByModel),
        typeof(ComputeInstanceDataDiskModel),
        typeof(ComputeInstanceDataMountModel),
        typeof(ComputeInstanceEnvironmentInfoModel),
        typeof(ComputeInstanceLastOperationModel),
        typeof(ComputeInstancePropertiesModel),
        typeof(ComputeInstanceSshSettingsModel),
        typeof(ComputeInstanceVersionModel),
        typeof(ComputeResourceModel),
        typeof(ComputeSchedulesModel),
        typeof(ComputeSecretsModel),
        typeof(ComputeStartStopScheduleModel),
        typeof(CronModel),
        typeof(CustomServiceModel),
        typeof(DataFactoryModel),
        typeof(DataLakeAnalyticsModel),
        typeof(DataLakeAnalyticsSchemaPropertiesModel),
        typeof(DatabricksModel),
        typeof(DatabricksComputeSecretsModel),
        typeof(DatabricksPropertiesModel),
        typeof(DockerModel),
        typeof(EndpointModel),
        typeof(EnvironmentVariableModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(ErrorResponseModel),
        typeof(HDInsightModel),
        typeof(HDInsightPropertiesModel),
        typeof(IdleShutdownSettingModel),
        typeof(ImageModel),
        typeof(ImageMetadataModel),
        typeof(InstanceTypeSchemaModel),
        typeof(InstanceTypeSchemaResourcesModel),
        typeof(KubernetesModel),
        typeof(KubernetesPropertiesModel),
        typeof(NodeStateCountsModel),
        typeof(PersonalComputeInstanceSettingsModel),
        typeof(RecurrenceModel),
        typeof(RecurrenceScheduleModel),
        typeof(ResourceIdModel),
        typeof(ScaleSettingsModel),
        typeof(ScaleSettingsInformationModel),
        typeof(ScheduleBaseModel),
        typeof(ScriptReferenceModel),
        typeof(ScriptsToExecuteModel),
        typeof(SetupScriptsModel),
        typeof(SkuModel),
        typeof(SslConfigurationModel),
        typeof(SynapseSparkModel),
        typeof(SynapseSparkPropertiesModel),
        typeof(SystemServiceModel),
        typeof(TmpfsOptionsModel),
        typeof(UserAccountCredentialsModel),
        typeof(VirtualMachineModel),
        typeof(VirtualMachineImageModel),
        typeof(VirtualMachineSchemaPropertiesModel),
        typeof(VirtualMachineSecretsModel),
        typeof(VirtualMachineSshCredentialsModel),
        typeof(VolumeDefinitionModel),
        typeof(VolumeOptionsModel),
    };
}
