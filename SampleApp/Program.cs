using System;
using TeamCitySharpAPI;
using TeamCitySharpAPI.Interfaces;

namespace SampleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting samples");

            CallBuildStatusMethods();

            Console.WriteLine("Samples Finished");
            Console.Read();
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

            var buildsByUserName = client.GetBuildsByUserName("admin");

            var nonSuccessfulBuildsForUserName = client.GetNonSuccessfulBuildsForUser("admin");
            var nonSuccessfulBuildCountByUser = client.GetNonSuccessfulBuildsForUser("admin").Count;

        }
    }
}
