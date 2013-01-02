using System.Collections.Generic;
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

        public List<Project> AllProjects()
        {
            var projectWrapper = _caller.Get<ProjectWrapper>("/app/rest/projects");

            return projectWrapper.Project;
        }

        public Project ProjectByName(string projectLocatorName)
        {
            var project = _caller.GetFormat<Project>("/app/rest/projects/name:{0}", projectLocatorName);

            return project;
        }

        public Project ProjectById(string projectLocatorId)
        {
            var project = _caller.GetFormat<Project>("/app/rest/projects/id:{0}", projectLocatorId);

            return project;
        }

        public Project ProjectDetails(Project project)
        {
            return ProjectById(project.Id);
        }

        public Project CreateProject(string projectName)
        {
            return _caller.Post<Project>(projectName, "/app/rest/projects/");
        }

        public void DeleteProject(string projectName)
        {
            _caller.DeleteFormat("/app/rest/projects/name:{0}", projectName);
        }

        public void DeleteProjectParameter(string projectName, string parameterName)
        {
            _caller.DeleteFormat("/app/rest/projects/name:{0}/parameters/{1}", projectName, parameterName);
        }
    }
}