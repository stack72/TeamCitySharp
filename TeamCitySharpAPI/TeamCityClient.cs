using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public class TeamCityClient : ITeamCityClient
    {
        private readonly TeamCityCaller _caller;

        public TeamCityClient(string hostName, string userName, string password, bool useSsl)
        {
            _caller = new TeamCityCaller(new Credentials
                                                    {
                                                        HostName = hostName,
                                                        Password = password,
                                                        UserName = userName,
                                                        UseSSL = useSsl
                                                    });
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var uri = _caller.CreateUri("/httpAuth/app/rest/projects");
            var request = _caller.Request(uri);

            var projects = JsonConvert.DeserializeObject<TeamCityProjectWrapper>(request).Projects;
            return projects;
        }

        public List<Build> GetAllBuilds()
        {
            var url = _caller.CreateUri("/httpAuth/app/rest/buildTypes");
            var request = _caller.Request(url);

            var buildType = JsonConvert.DeserializeObject<BuildType>(request);

            return buildType.Builds;
        }

        public Project GetProjectDetailsByName(string projectLocatorName)
        {
            var url = _caller.CreateUri(string.Format("httpAuth/app/rest/projects/name:{0}", projectLocatorName));
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<Project>(request);
        }

        public Project GetProjectDetailsById(string projectLocatorId)
        {
            var url = _caller.CreateUri(string.Format("httpAuth/app/rest/projects/id:{0}", projectLocatorId));
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<Project>(request);
        }

        public Build GetBuildConfigByName(string buildConfigName)
        {
            var url = _caller.CreateUri(string.Format("/httpAuth/app/rest/buildTypes/name:{0}", buildConfigName));
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<Build>(request);
        }

        public Build GetBuildConfigById(string buildConfigId)
        {
            return null;
        }


        public List<Build> GetBuildsPerProject(string projectName)
        {
            var url = _caller.CreateUri(string.Format("/httpAuth/app/rest/projects/id:{0}/buildTypes", projectName));
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<BuildConfig>(request).Builds;
        }

        public List<Build> GetSuccessfulBuildDetails(string projectHref)
        {
            var url = _caller.CreateUri(string.Format("{0}/builds?status=SUCCESS", projectHref));
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<BuildWrapper>(request).Builds;
        }




        public Build GetLastSuccessfulBuildDetail(string projectHref)
        {
            return GetSuccessfulBuildDetails(projectHref).FirstOrDefault();
        }
    
        public List<Build> GetCancelledBuildDetails(string projectHref)
        {
            var url = _caller.CreateUri(string.Format("{0}/builds?cancelled=true", projectHref));
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<BuildWrapper>(request).Builds;
        }

        public Build GetLastCancelledBuildDetail(string projectHref)
        {
            return GetCancelledBuildDetails(projectHref).FirstOrDefault();
        }
    
        public List<Build> GetFailedBuildDetails(string  projectHref)
        {
            var url = _caller.CreateUri(string.Format("{0}/builds?status=FAILED", projectHref));
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<BuildWrapper>(request).Builds;
        }

        
    }
}
