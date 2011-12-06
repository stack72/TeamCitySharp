using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_get_agent_details
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new ClientSetup().Connect();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void it_throws_exception_when_no_host()
        {
            var client = new TeamCityClient(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void it_throws_exception_when_host_url_invalid()
        {
            var client = new TeamCityClient("test:81");
            client.Connect(ClientSetup.TeamCityClientUserName, ClientSetup.TeamCityClientPassword);

            var agents = client.AllAgents();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_throws_exception_when_no_client_connection_made()
        {
            var client = new TeamCityClient("localhost:81");

            var agents = client.AllAgents();

            //Assert: Exception
        }

        [Test]
        public void it_returns_all_agents()
        {
            List<Agent> agents = _client.AllAgents();

            Assert.That(agents.Any(), "No agents were found");
        }

        [Test]
        public void it_returns_last_build_status_for_agent()
        {
            Build lastBuild = _client.LastBuildByAgent(ClientSetup.TeamCityAgentName);

            Assert.That(lastBuild != null, "No build information found for the last build on the specified agent");
        }
    }
}