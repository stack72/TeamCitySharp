using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface ITeamCityProjects
    {
        List<Project> GetAllProjects();
        Project GetProjectDetailsByProjectName(string projectLocatorName);
        Project GetProjectDetailsByProjectId(string projectLocatorId);
    }

    public interface ITeamCityBuilds
    {
        List<Build> GetAllBuilds();
        Build GetBuildConfigByBuildConfigurationName(string buildConfigName);
        Build GetBuildConfigByBuildConfigurationId(string buildConfigId);
        List<Build> GetBuildsPerProjectId(string projectId);
    }

}