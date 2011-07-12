using System;
using System.Linq;
using TeamCitySharpAPI;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TeamCityClient("teamcity.paulstack.co.uk:8080/", "stack72", "St1ngers72", false);
            var projects = client.GetAllProjects();
            
            foreach (var teamCityProject in projects)
            {
                var projectDetails = client.GetProjectDetailsById(teamCityProject.Id);
                
            }

            Console.Read();
        }
    }
}
