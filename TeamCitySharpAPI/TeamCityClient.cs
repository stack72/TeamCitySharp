using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public class TeamCityClient : IProjectClient
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

        public IEnumerable<TeamCityProject> GetAllProjects()
        {
            var uri = _caller.CreateUri("/httpAuth/app/rest/projects");
            var request = _caller.Request(uri);

            var projects = JsonConvert.DeserializeObject<TeamCityProjectWrapper>(request).Projects;
            return projects;
        }

        public TeamCityProject GetProjectDetailsById(string projectLocator)
        {
            var url = _caller.CreateUri(string.Format("httpAuth/app/rest/projects/id:{0}", projectLocator));
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<TeamCityProject>(request);
        }

        public BuildOverView GetBuildDetails(string projectHref)
        {
            var url = _caller.CreateUri(projectHref);
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<BuildOverView>(request);
        }

        public BuildDetail GetSuccessfulBuildDetails(string projectHref)
        {
            var url = _caller.CreateUri(string.Format("{0}/builds?status=SUCCESS", projectHref));
            var request = _caller.Request(url);

            return JsonConvert.DeserializeObject<BuildDetail>(request);
        }

        public Build GetLastSuccessfulBuildDetail(string projectHref)
        {
            return GetSuccessfulBuildDetails(projectHref).Build.First();
        }
    }

    public interface IProjectClient
    {
        IEnumerable<TeamCityProject> GetAllProjects();
        TeamCityProject GetProjectDetailsById(string projectLocator);
        BuildOverView GetBuildDetails(string projectHref);
        BuildDetail GetSuccessfulBuildDetails(string projectHref);
        Build GetLastSuccessfulBuildDetail(string projectHref);
    }
}
