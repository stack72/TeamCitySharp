using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Instantiating_A_Client_Without_Host_Throws_Exception()
        {
            TeamCityAgents client = new Client(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void Instantiating_A_Client_With_A_Host_That_Doesnt_Exist_Throws_Exception()
        {
            TeamCityAgents client = new Client("test:81");
            client.Connect("admin", "qwerty");

            var agents = client.GetAllAgents();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Trying_To_Get_Agents_WithOut_Connecting_Throws_Exception()
        {
            TeamCityAgents client = new Client("localhost:81");

            var agents = client.GetAllAgents();

            //Assert: Exception
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