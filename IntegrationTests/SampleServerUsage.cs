using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using TeamCitySharpAPI;
using TeamCitySharpAPI.DomainEntities;
using TeamCitySharpAPI.Interfaces;

namespace IntegrationTests
{
    [TestFixture]
    public class SampleServerUsage
    {
        private TeamCityServer _client;
        
        [SetUp]
        public void SetUp()
        {
            _client = new Client("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        [Test]
        public void Get_Server_Information()
        {
            Server serverInfo = _client.GetServerInfo();

            Assert.That(serverInfo != null, "The server is not returning any information");
        }

        [Test]
        public void Get_List_Plugins()
        {
            List<Plugin> plugins = _client.GetAllServerPlugins();

            Assert.That(plugins.Any(), "Server is not returning a plugin list");
        }
    }
}