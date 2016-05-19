using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public interface IProjects
  {
    List<Project> All();
    Projects GetFields(string fields);
    Project ByName(string projectLocatorName);
    Project ById(string projectLocatorId);
    Project Details(Project project);
    Project Create(string projectName);
    Project Create(string projectName, string sourceId, string projectId = "");
    Project Move(string projectId, string destinationId);
    Project Copy(string projectid, string projectName, string newProjectId, string parentProjectId = "");
    string GenerateID(string projectName);
    void Delete(string projectName);
    void DeleteById(string projectId);
    void DeleteProjectParameter(string projectName, string parameterName);
    void SetProjectParameter(string projectName, string settingName, string settingValue);
    bool ModifParameters(string projectId, string mainprojectbranch, string variablePath);
    bool ModifSettings(string projectId, string description, string fullProjectName);
  }
}