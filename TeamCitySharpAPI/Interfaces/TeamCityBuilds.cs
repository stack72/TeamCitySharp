using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface TeamCityBuilds: ClientConnection
    {
        List<BuildType> GetAllBuildTypes();
        BuildType GetBuildTypeByBuildConfigurationName(string buildConfigName);
        BuildType GetBuildTypeByBuildConfigurationId(string buildConfigId);
        List<BuildType> GetBuildTypesPerProjectId(string projectId);
        List<BuildType> GetBuildTypesPerProjectName(string projectName);
    }

}