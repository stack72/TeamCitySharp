using System;
using System.Linq;
using TeamCitySharpAPI;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TeamCityClient("localhost:81", "admin", "qwerty", false);
            var projects = client.GetAllProjects();
            
            foreach (var teamCityProject in projects)
            {
                var projectDetails = client.GetProjectDetailsById(teamCityProject.Id);
                foreach (var buildType in projectDetails.BuildTypes.BuildTypes)
                {
                    var buildDetails = client.GetBuildDetails(buildType.Href);

                    var successfulBuilds = client.GetSuccessfulBuildDetails(buildDetails.Href);

                    var lastSuccessfulBuild = client.GetLastSuccessfulBuildDetail(buildDetails.Href);
                }
            }

            Console.Read();
        }
    }
}
