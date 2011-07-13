using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface TeamCityBuilds: ClientConnection
    {
        List<Build> GetAllBuilds();
        Build GetBuildConfigByBuildConfigurationName(string buildConfigName);
        Build GetBuildConfigByBuildConfigurationId(string buildConfigId);
        List<Build> GetBuildsPerProjectId(string projectId);
        List<Build> GetBuildsPerProjectName(string projectName);
    }

}