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
            
            //gets a list of build configs for the entire system
            var builds = client.GetAllBuilds();

            //gets a list of projects in the system
            var projects = client.GetAllProjects();

            //gets a project by a specific name
            var projectByName = client.GetProjectDetailsByProjectLocatorName("nPUC");
            
            //gets a project by a specific projectId
            var projectById = client.GetProjectDetailsByProjectLocatorId("project6");

            //get buildsPerProject
            var buildsPerProject = client.GetBuildsPerProjectId("project6");

            //get build config per buildName
            var buildConfigPerName = client.GetBuildConfigByBuildConfigurationName("Local Debug Build");

            //get build config per buildId
            var buildConfigPerBuildId = client.GetBuildConfigByBuildConfigurationId("bt8");

            Console.Read();
        }
    }
}
