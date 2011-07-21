using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TeamCitySharpAPI;
using TeamCitySharpAPI.DomainEntities;
using TeamCitySharpAPI.Interfaces;

namespace IntegrationTests
{
    [TestFixture]
    public class SampleAgentUsage
    {
        private TeamCityAgents _client;

        [SetUp]
        public void SetUp()
        {
            _client = new Client("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        [Test]
        public void Get_All_Agents()
        {
            List<Agent> agents = _client.GetAllAgents();

            Assert.That(agents.Any(), "No agents were found");
        }

        [Test]
        public void Get_Last_Build_Details_By_Specified_Agent()
        {
            var agentName = "stack-LP";

            Build lastBuild = _client.GetLastBuildBySpecificAgentName(agentName);

            Assert.That(lastBuild != null, "No build information found for the last build on the specified agent");
        }
        
    }
}