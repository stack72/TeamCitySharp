using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IProjects
    {
        List<Project> All();
        List<DomainEntities.CCTray.Project> CruiseControlTray();
        Project ByName(string projectLocatorName);
        Project ById(string projectLocatorId);
        Project Details(Project project);
        Project Create(string projectName);
        void Delete(string projectName);
        void DeleteProjectParameter(string projectName, string parameterName);
        void SetProjectParameter(string projectName, string settingName, string settingValue);
    }
}