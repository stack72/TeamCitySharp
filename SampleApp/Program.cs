using System;
using System.Linq;
using TeamCitySharpAPI;

namespace SampleApp
{
    class Program
    {
        static void Main()
        {
            CallBuildMethods();
            CallProjectMethods();

            Console.Read();
        }

        private static void CallBuildMethods()
        {
            TeamCityBuilds teamCityBuildClient = new Client("localhost:81");
            teamCityBuildClient.Connect("admin", "qwerty");
            
            //gets a list of build configs for the entire system
            var builds = teamCityBuildClient.GetAllBuilds();

            //get buildsPerProject
            var buildsPerProject = teamCityBuildClient.GetBuildsPerProjectId("project6");

            //get build config per buildName
            var buildConfigPerName = teamCityBuildClient.GetBuildConfigByBuildConfigurationName("Local Debug Build");

            //get build config per buildId
            var buildConfigPerBuildId = teamCityBuildClient.GetBuildConfigByBuildConfigurationId("bt8");
        }

        private static void CallProjectMethods()
        {
            TeamCityProjects projectClient = new Client("localhost:81");
            projectClient.Connect("admin", "qwerty");
           
            //gets a list of projects in the system
            var projects = projectClient.GetAllProjects();

            //gets a project by a specific name
            var projectByName = projectClient.GetProjectDetailsByProjectName("nPUC");

            //gets a project by a specific projectId
            var projectById = projectClient.GetProjectDetailsByProjectId("project6");
        }
    
        private static void GetBuildStatusMethods()
        {
            var client = new Client("localhost:81");
            client.Connect("admin", "qwerty");

            var successfulBuilds = client.GetSuccessfulBuildsByProjectName("nPUC");
            var lastSuccessfulBuild = client.GetLastSuccessfulBuildByProjectName("nPUC");

            //TODO
            var cancelledBuilds = client.GetCancelledBuildsByProjectName("nPUC");
            var lastCancelled = client.GetLastCancelledBuildByProjectName("nPUC");

            
        }
    }
}
