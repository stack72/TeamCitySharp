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
      _client = new TeamCityClient("teamcity.codebetter.com");
      _client.Connect("teamcitysharpuser", "qwerty");
    }

    [Test]
    public void it_throws_exception_when_no_host()
    {
      Assert.Throws<ArgumentNullException>(() => new TeamCityClient(null));
    }

    [Test]
    public void it_throws_exception_when_host_url_invalid()
    {
      var client = new TeamCityClient("teamcity:81");
      client.Connect("teamcitysharpuser", "qwerty");

      Assert.Throws<WebException>(() => client.Agents.All());
    }

    [Test]
    public void it_throws_exception_when_no_client_connection_made()
    {
      var client = new TeamCityClient("teamcity.codebetter.com");

      Assert.Throws<ArgumentException>(() => client.Agents.All());
    }

    [Test]
    public void it_returns_all_agents()
    {
      List<Agent> agents = _client.Agents.All();

      Assert.That(agents.Any(), "No agents were found");
    }

    [TestCase("agent01")]
    public void it_returns_last_build_status_for_agent(string agentName)
    {
      Build lastBuild = _client.Builds.LastBuildByAgent(agentName);

      Assert.That(lastBuild != null, "No build information found for the last build on the specified agent");
    }
  }
}