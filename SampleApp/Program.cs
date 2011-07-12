using System;
using System.Linq;
using TeamCitySharpAPI;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TeamCityClient("localhost:81", "admin", "p@ssword", false);
            var projects = client.GetAllProjects();
            
            foreach (var teamCityProject in projects)
            {
                var projectDetails = client.GetProjectDetailsById(teamCityProject.Id);
                
            }

            Console.Read();
        }
    }
}
