using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Instantiating_A_Client_Without_Host_Throws_Exception()
        {
            TeamCityServer client = new Client(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void Instantiating_A_Client_With_A_Host_That_Doesnt_Exist_Throws_Exception()
        {
            TeamCityServer client = new Client("test:81");
            client.Connect("admin", "qwerty");

            var plugins = client.GetAllServerPlugins();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Trying_To_Get_Plugins_WithOut_Connecting_Throws_Exception()
        {
            TeamCityServer client = new Client("localhost:81");

            var plugins = client.GetAllServerPlugins();

            //Assert: Exception
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