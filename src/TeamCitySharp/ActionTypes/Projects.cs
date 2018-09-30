using System.Collections.Generic;
using EasyHttp.Http;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    using System.Net;

    using EasyHttp.Infrastructure;

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
            return GetProject(string.Format("name:{0}", projectLocatorName));
        }

        public Project ById(string projectLocatorId)
        {
            return GetProject(projectLocatorId);
        }

        public Project Details(Project project)
        {
            return ById(project.Id);
        }

        public Project Create(string projectName)
        {
            return _caller.Post<Project>(projectName, HttpContentTypes.TextPlain, "/app/rest/projects/", HttpContentTypes.ApplicationJson);
        }

        public bool SetName(string projectCode, string name)
        {
            try
            {
                var response = _caller.Put(name, HttpContentTypes.TextPlain, string.Format("/app/rest/projects/{0}/name", projectCode), null);
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (HttpException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        public Project Create(string projectName, string projectId)
        {

            var content = string.Format
                (@"<newProjectDescription name='{0}' id='{1}' copyAllAssociatedSettings='true'> </newProjectDescription>"
                , projectName, projectId);
            /* extended xml version:
             * <newProjectDescription name='New Project Name' id='newProjectId' copyAllAssociatedSettings='true'><parentProject locator='id:project1'/><sourceProject locator='id:project2'/></newProjectDescription>
             * more details could be found in documentation: https://confluence.jetbrains.com/display/TCD9/REST+API#RESTAPI-ProjectSettings
             */
            return _caller.Post<Project>(content, HttpContentTypes.ApplicationXml, "/app/rest/projects/", HttpContentTypes.ApplicationJson);
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

        private Project GetProject(string locator)
        {
            try
            {
                var project = _caller.GetFormat<Project>("/app/rest/projects/{0}", locator);
                return project;
            }
            catch (HttpException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw;
            }
        }
    }
}