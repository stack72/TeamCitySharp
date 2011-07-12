using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface ITeamCityClient
    {
        IEnumerable<Project> GetAllProjects();
        List<Build> GetAllBuilds();
        Project GetProjectDetailsByProjectLocatorName(string projectLocatorName);
        Project GetProjectDetailsByProjectLocatorId(string projectLocatorId);
        Build GetBuildConfigByBuildConfigurationName(string buildConfigName);
        Build GetBuildConfigByBuildConfigurationId(string buildConfigId);
        List<Build> GetBuildsPerProjectId(string projectId);
    }
}