using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_get_server_info
    {
        private TeamCityClient _client;
        
        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void it_throws_exception_when_no_url_passed()
        {
            var client = new TeamCityClient(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void it_throws_exception_when_host_does_not_exist()
        {
            var client = new TeamCityClient("test:81");
            client.Connect("admin", "qwerty");

            var plugins = client.AllServerPlugins();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_throws_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient("localhost:81");

            var plugins = client.AllServerPlugins();

            //Assert: Exception
        }

        [Test]
        public void it_returns_server_info()
        {
            Server serverInfo = _client.ServerInfo();

            Assert.That(serverInfo != null, "The server is not returning any information");
        }

        [Test]
        public void it_returns_all_server_plugins()
        {
            List<Plugin> plugins = _client.AllServerPlugins();

            Assert.That(plugins.Any(), "Server is not returning a plugin list");
        }
    }
}