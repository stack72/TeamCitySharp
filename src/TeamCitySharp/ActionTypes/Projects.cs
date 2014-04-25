using System.Collections.Generic;
using EasyHttp.Http;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class Projects : IProjects
    {
        private readonly TeamCityCaller _caller;

        internal Projects(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<Project> All()
        {
            var projectWrapper = _caller.Get<ProjectWrapper>("/app/rest/projects");

            return projectWrapper.Project;
        }

        public Project ByName(string projectLocatorName)
        {
            var project = _caller.GetFormat<Project>("/app/rest/projects/name:{0}", projectLocatorName);

            return project;
        }

        public Project ById(string projectLocatorId)
        {
            var project = _caller.GetFormat<Project>("/app/rest/projects/id:{0}", projectLocatorId);

            return project;
        }

        public Project Details(Project project)
        {
            return ById(project.Id);
        }

        public Project Create(string projectName)
        {
            return _caller.Post<Project>(projectName, HttpContentTypes.TextPlain, "/app/rest/projects/", HttpContentTypes.ApplicationJson);
        }

        public void Delete(string projectName)
        {
            _caller.DeleteFormat("/app/rest/projects/name:{0}", projectName);
        }

        public void DeleteProjectParameter(string projectName, string parameterName)
        {
            _caller.DeleteFormat("/app/rest/projects/name:{0}/parameters/{1}", projectName, parameterName);
        }

        public void SetProjectParameter(string projectName, string settingName, string settingValue)
        {
            _caller.PutFormat(settingValue, "/app/rest/projects/name:{0}/parameters/{1}", projectName, settingName);
        }
    }
}