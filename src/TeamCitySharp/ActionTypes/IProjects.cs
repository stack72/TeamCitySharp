using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IProjects
    {
        List<Project> All();
        Project ByName(string projectLocatorName);
        Project ById(string projectLocatorId);
        Project Details(Project project);
        Project Create(string projectName);
        Project Create(string projectName, string projectId);
        void Delete(string projectName);
        void DeleteProjectParameter(string projectName, string parameterName);
        void SetProjectParameter(string projectName, string settingName, string settingValue);
        bool SetName(string projectCode, string name);
    }
}