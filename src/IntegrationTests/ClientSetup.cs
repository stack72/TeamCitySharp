using System.Configuration;

namespace TeamCitySharp.IntegrationTests
{
    class ClientSetup
    {
        public static string TeamCityClientUrl = ConfigurationManager.AppSettings["TeamCityClientUrl"];
        public static string TeamCityClientUserName = ConfigurationManager.AppSettings["TeamCityClientUserName"];
        public static string TeamCityClientPassword = ConfigurationManager.AppSettings["TeamCityClientPassword"];
        public static string TeamCityAgentName = ConfigurationManager.AppSettings["TeamCityAgentName"];
        public static string TestBuildConfigId = ConfigurationManager.AppSettings["TestBuildConfigId"];
        public static string TestBuildConfigName = ConfigurationManager.AppSettings["TestBuildConfigName"];
        public static string TestProjectId = ConfigurationManager.AppSettings["TestProjectId"];
        public static string TestProjectName = ConfigurationManager.AppSettings["TestProjectName"];
        public static string TestTag = ConfigurationManager.AppSettings["TestTag"];
        public static string TestChangeId = ConfigurationManager.AppSettings["TestChangeId"];
        public static string TestVcsRootId = ConfigurationManager.AppSettings["TestVcsRootId"];
        public static string UserGroupName = "ALL_USERS_GROUP";

        private ITeamCityClient _client;

        public ITeamCityClient Connect()
        {
            _client = new TeamCityClient(TeamCityClientUrl);
            _client.Connect(TeamCityClientUserName, TeamCityClientPassword);

            return _client;
        }
    }
}
