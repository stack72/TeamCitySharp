using System;
using System.Linq;
using TeamCitySharpAPI;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CallBuildMethods();
            CallProjectMethods();

            Console.Read();
        }

        private static void CallBuildMethods()
        {
            TeamCityBuilds buildClient = new TeamCityClient("localhost:81");
            buildClient.Connect("admin", "qwerty");
            
            //gets a list of build configs for the entire system
            var builds = buildClient.GetAllBuilds();

            //get buildsPerProject
            var buildsPerProject = buildClient.GetBuildsPerProjectId("project6");

            //get build config per buildName
            var buildConfigPerName = buildClient.GetBuildConfigByBuildConfigurationName("Local Debug Build");

            //get build config per buildId
            var buildConfigPerBuildId = buildClient.GetBuildConfigByBuildConfigurationId("bt8");
        }

        private static void CallProjectMethods()
        {
            TeamCityProjects projectClient = new TeamCityClient("localhost:81");
            projectClient.Connect("admin", "qwerty");
           
            //gets a list of projects in the system
            var projects = projectClient.GetAllProjects();

            //gets a project by a specific name
            var projectByName = projectClient.GetProjectDetailsByProjectName("nPUC");

            //gets a project by a specific projectId
            var projectById = projectClient.GetProjectDetailsByProjectId("project6");
        }
    }
}
