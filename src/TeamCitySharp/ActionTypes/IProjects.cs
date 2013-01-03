using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IProjects
    {
        List<Project> AllProjects();
        Project ProjectByName(string projectLocatorName);
        Project ProjectById(string projectLocatorId);
        Project ProjectDetails(Project project);
        Project CreateProject(string projectName);
        void DeleteProject(string projectName);
        void DeleteProjectParameter(string projectName, string parameterName);
        void SetProjectParameter(string projectName, string settingName, string settingValue);
    }
}