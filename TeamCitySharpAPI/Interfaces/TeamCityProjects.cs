using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface TeamCityProjects
    {
        List<Project> GetAllProjects();
        Project GetProjectDetailsByProjectName(string projectLocatorName);
        Project GetProjectDetailsByProjectId(string projectLocatorId);
    }
}