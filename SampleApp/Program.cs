using System;
using TeamCitySharpAPI;
using TeamCitySharpAPI.Interfaces;

namespace SampleApp
{
    class Program
    {
        static void Main()
        {
            //CallBuildMethods();
            //CallProjectMethods();
            //CallBuildStatusMethods();
            //CallUserMethods();
            //CallAgentMethods();
            //CallVcsRootMethods();
            //CallServerInformation();
            CallUserGroupMethods();

            Console.Read();
        }

        private static void CallServerInformation()
        {
            TeamCityServer client = new Client("localhost:81");
            client.Connect("admin", "qwerty");

            var serverInfo = client.GetServerInfo();
        }

        private static void CallBuildMethods()
        {
            TeamCityBuilds teamCityBuildClient = new Client("localhost:81");
            teamCityBuildClient.Connect("admin", "qwerty");
            
            //gets a list of build configs for the entire system
            var builds = teamCityBuildClient.GetAllBuildTypes();

            //get buildsPerProject
            var buildsPerProject = teamCityBuildClient.GetBuildTypesPerProjectId("project6");

            //get build config per buildName
            var buildConfigPerName = teamCityBuildClient.GetBuildTypeByBuildConfigurationName("Local Debug Build");

            //get build config per buildId
            var buildConfigPerBuildId = teamCityBuildClient.GetBuildTypeByBuildConfigurationId("bt8");
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

        private static void CallBuildStatusMethods()
        {
            TeamCityBuildStatus client = new Client("localhost:81");
            client.Connect("admin", "qwerty");

            var successfulBuilds = client.GetSuccessfulBuildsByBuildConfigName("Local Debug Build");
            var lastSuccessfulBuild = client.GetLastSuccessfulBuildByBuildConfigName("Local Debug Build");

            var cancelledBuilds = client.GetCancelledBuildsByBuildConfigName("Local Debug Build");
            var lastCancelled = client.GetLastCancelledBuildByBuildConfigName("Local Debug Build");

            var failedBuilds = client.GetFailedBuildsByBuildConfigName("Local Debug Build");
            var lastFailed = client.GetLastFailedBuildByBuildConfigName("Local Debug Build");

            var errorBuilds = client.GetErrorBuildsByBuildConfigName("Local Debug Build");
            var lastError = client.GetLastErrorBuildByBuildConfigName("Local Debug Build");

            var lastBuildStatus = client.GetLastBuildStatusByBuildConfigName("Local Debug Build");
        }
    
        private static void CallUserMethods()
        {
            TeamCityUsers client = new Client("localhost:81");
            client.Connect("admin", "qwerty");

            var users = client.GetAllUsers();

        }

        private static void CallUserGroupMethods()
        {
            TeamCityUserGroups client = new Client("localhost:81");
            client.Connect("admin", "qwerty");

            var userGroups = client.GetAllUserGroups();
            var usersInRole = client.GetAllUsersByUserGroup("ALL_USERS_GROUP");

            var roles = client.GetAllUserRolesByUserGroup("ALL_USERS_GROUP");
        }

        private static void CallAgentMethods()
        {
            TeamCityAgents client = new Client("localhost:81");
            client.Connect("admin", "qwerty");

            var agents = client.GetAllAgents();
        }
    
        private static void CallVcsRootMethods()
        {
            TeamCityVcsRoots client = new Client("localhost:81");
            client.Connect("admin", "qwerty");

            var vcsRoots = client.GetAllVcsRoots();
        }
    }
}
