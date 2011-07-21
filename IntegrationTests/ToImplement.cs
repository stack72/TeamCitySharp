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

            var cancelledBuilds = client.GetCancelledBuildsByBuildConfigName("Local Debug Build");
            var lastCancelled = client.GetLastCancelledBuildByBuildConfigName("Local Debug Build");

        }
    }
}
