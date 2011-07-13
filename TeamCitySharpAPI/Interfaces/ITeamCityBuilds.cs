using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface ITeamCityBuilds
    {
        List<Build> GetAllBuilds();
        Build GetBuildConfigByBuildConfigurationName(string buildConfigName);
        Build GetBuildConfigByBuildConfigurationId(string buildConfigId);
        List<Build> GetBuildsPerProjectId(string projectId);
    }

}