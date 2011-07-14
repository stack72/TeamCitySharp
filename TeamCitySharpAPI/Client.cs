using System.Collections.Generic;
using System.Linq;
using TeamCitySharpAPI.DomainEntities;
using TeamCitySharpAPI.Utilities;

namespace TeamCitySharpAPI
{
    public class Client : TeamCityProjects, TeamCityBuilds, TeamCityBuildStatus
    {
        private readonly TeamCityCaller _caller;

        public Client(string hostName, bool useSsl = false)
        {
            _caller = new TeamCityCaller(hostName, useSsl);
        }

        public void Connect(string userName, string password, bool actAsGuest = false)
        {
            _caller.Connect(userName, password, actAsGuest);
        }

        public List<Project> GetAllProjects()
        {
            var projectWrapper = _caller.Get<TeamCityProjectWrapper>("/httpAuth/app/rest/projects");

            return projectWrapper.Project;
        }

        public List<Build> GetAllBuilds()
        {
            var buildType = _caller.Get<BuildTypeWrapper>("/httpAuth/app/rest/buildTypes");

            return buildType.BuildType;
        }

        public Project GetProjectDetailsByProjectName(string projectLocatorName)
        {
            var project = _caller.Get<Project>(string.Format("/httpAuth/app/rest/projects/name:{0}", projectLocatorName));

            return project;
        }

        public Project GetProjectDetailsByProjectId(string projectLocatorId)
        {
            var project = _caller.Get<Project>(string.Format("/httpAuth/app/rest/projects/id:{0}", projectLocatorId));

            return project;
        }

        public Build GetBuildConfigByBuildConfigurationName(string buildConfigName)
        {
            var build = _caller.Get<Build>(string.Format("/httpAuth/app/rest/buildTypes/name:{0}", buildConfigName));
            
            return build;
        }

        public Build GetBuildConfigByBuildConfigurationId(string buildConfigId)
        {
            var build = _caller.Get<Build>(string.Format("/httpAuth/app/rest/buildTypes/id:{0}", buildConfigId));

            return build;
        }

        public List<Build> GetBuildsPerProjectId(string projectId)
        {
            var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/projects/id:{0}/buildTypes", projectId));

            return buildWrapper.BuildType;
        }

        public List<Build> GetBuildsPerProjectName(string projectName)
        {
            var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/projects/name:{0}/buildTypes", projectName));

            return buildWrapper.BuildType;
        }
   
        //public List<Build> GetCancelledBuildDetails(string projectHref)
        //{
        //    var url = _caller.CreateUri(string.Format("{0}/builds?cancelled=true", projectHref));
        //    var request = _caller.Request(url);

        //    return JsonConvert.DeserializeObject<BuildWrapper>(request).TeamCityBuilds;
        //}

        //public Build GetLastCancelledBuildDetail(string projectHref)
        //{
        //    return GetCancelledBuildDetails(projectHref).FirstOrDefault();
        //}
    
        //public List<Build> GetFailedBuildDetails(string  projectHref)
        //{
        //    var url = _caller.CreateUri(string.Format("{0}/builds?status=FAILED", projectHref));
        //    var request = _caller.Request(url);

        //    return JsonConvert.DeserializeObject<BuildWrapper>(request).TeamCityBuilds;
        //}

        public List<Build> GetSuccessfulBuildsByProjectName(string projectName)
        {
            var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/name:{0}/builds?status=SUCCESS", projectName));

            return buildWrapper.BuildType;
        }

        public Build GetLastSuccessfulBuildByProjectName(string projectName)
        {
            return GetSuccessfulBuildsByProjectName(projectName).FirstOrDefault();
        }

        public List<Build> GetCancelledBuildsByProjectName(string projectName)
        {
            return null;
        }

        public Build GetLastCancelledBuildByProjectName(string projectName)
        {
            return null;
        }
    }
}
