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
    private ITeamCityClient _client;

    [SetUp]
    public void SetUp()
    {
      _client = new TeamCityClient("localhost:81");
      _client.Connect("admin", "qwerty");
    }

    [Test]
    public void it_throws_exception_when_no_url_passed()
    {
      Assert.Throws<ArgumentNullException>(() => new TeamCityClient(null));
    }

    [Test]
    public void it_throws_exception_when_host_does_not_exist()
    {
      var client = new TeamCityClient("test:81");
      client.Connect("admin", "qwerty");

      Assert.Throws<WebException>(() => client.ServerInformation.AllPlugins());
    }

    [Test]
    public void it_throws_exception_when_no_connection_formed()
    {
      var client = new TeamCityClient("teamcity.codebetter.com");

      Assert.Throws<ArgumentException>(() => client.ServerInformation.AllPlugins());

      //Assert: Exception
    }

    [Test]
    public void it_returns_server_info()
    {
      Server serverInfo = _client.ServerInformation.ServerInfo();

      Assert.That(serverInfo != null, "The server is not returning any information");
    }

    [Test]
    public void it_returns_all_server_plugins()
    {
      List<Plugin> plugins = _client.ServerInformation.AllPlugins();

      Assert.IsNotNull(plugins, "Server is not returning a plugin list");
    }
  }
}