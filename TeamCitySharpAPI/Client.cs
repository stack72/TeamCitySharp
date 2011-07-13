using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TeamCitySharpAPI.DomainEntities;
using TeamCitySharpAPI.Utilities;

namespace TeamCitySharpAPI
{
    public class Client : TeamCityProjects, TeamCityBuilds, TeamCityBuildStatus
    {
        private readonly TeamCityCaller _caller;

        public Client(string hostName)
        {
            _caller = new TeamCityCaller(hostName);
        }

        public void Connect(string userName, string password, bool useSsl = false, bool actAsGuest = false)
        {
            _caller.Connect(userName, password, useSsl, actAsGuest);
        }

        public List<Project> GetAllProjects()
        {
            var uri = _caller.CreateUri("/httpAuth/app/rest/projects");
            var request = _caller.Request(uri);

            var projects = Deserialise.DeserializeFromJson<TeamCityProjectWrapper>(request).Projects;
            return projects;
        }

        public List<Build> GetAllBuilds()
        {
            var url = _caller.CreateUri("/httpAuth/app/rest/buildTypes");
            var request = _caller.Request(url);

            var buildType = Deserialise.DeserializeFromJson<BuildType>(request);

            return buildType.Builds;
        }

        public Project GetProjectDetailsByProjectName(string projectLocatorName)
        {
            var url = _caller.CreateUri(string.Format("httpAuth/app/rest/projects/name:{0}", projectLocatorName));
            var request = _caller.Request(url);

            return Deserialise.DeserializeFromJson<Project>(request);
        }

        public Project GetProjectDetailsByProjectId(string projectLocatorId)
        {
            var url = _caller.CreateUri(string.Format("httpAuth/app/rest/projects/id:{0}", projectLocatorId));
            var request = _caller.Request(url);

            return Deserialise.DeserializeFromJson<Project>(request);
        }

        public Build GetBuildConfigByBuildConfigurationName(string buildConfigName)
        {
            var url = _caller.CreateUri(string.Format("/httpAuth/app/rest/buildTypes/name:{0}", buildConfigName));
            var request = _caller.Request(url);

            return Deserialise.DeserializeFromJson<Build>(request);
        }

        public Build GetBuildConfigByBuildConfigurationId(string buildConfigId)
        {
            var url = _caller.CreateUri(string.Format("/httpAuth/app/rest/buildTypes/id:{0}", buildConfigId));
            var request = _caller.Request(url);

            return Deserialise.DeserializeFromJson< Build > (request);
        }

        public List<Build> GetBuildsPerProjectId(string projectId)
        {
            var url = _caller.CreateUri(string.Format("/httpAuth/app/rest/projects/id:{0}/buildTypes", projectId));
            var request = _caller.Request(url);

            return Deserialise.DeserializeFromJson<BuildWrapper>(request).Builds;
        }

        public List<Build> GetBuildsPerProjectName(string projectName)
        {
            var url = _caller.CreateUri(string.Format("/httpAuth/app/rest/projects/name:{0}/buildTypes", projectName));
            var request = _caller.Request(url);

            return Deserialise.DeserializeFromJson<BuildWrapper>(request).Builds;
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
            var url = _caller.CreateUri(string.Format("/httpAuth/app/rest/buildTypes/name:{0}/builds?status=SUCCESS", projectName));
            var request = _caller.Request(url);

            return Deserialise.DeserializeFromJson<BuildWrapper>(request).Builds;
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
