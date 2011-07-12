using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharpAPI
{
    public class TeamCityClient: IProjectClient
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

    }

    public interface IProjectClient
    {
        IEnumerable<TeamCityProject> GetAllProjects();
        TeamCityProject GetProjectDetailsById(string projectLocator);
    }
}
