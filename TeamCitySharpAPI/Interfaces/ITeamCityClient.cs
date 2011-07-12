using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface ITeamCityClient
    {
        IEnumerable<Project> GetAllProjects();
        List<Build> GetAllBuilds();
        Project GetProjectDetailsByName(string projectLocatorName);
        Project GetProjectDetailsById(string projectLocatorId);
        Build GetBuildConfigByBuildConfigurationName(string buildConfigName);
        Build GetBuildConfigByBuildConfigurationId(string buildConfigId);
        List<Build> GetBuildsPerProject(string projectName);
        //List<Build> GetSuccessfulBuildDetails(string projectHref);
        //Build GetLastSuccessfulBuildDetail(string projectHref);
        //List<Build> GetCancelledBuildDetails(string projectHref);
        //Build GetLastCancelledBuildDetail(string projectHref);
        //List<Build> GetFailedBuildDetails(string projectHref);
    }
}