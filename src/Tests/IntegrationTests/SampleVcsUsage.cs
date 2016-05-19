using System;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_interacting_to_get_vcs_details
  {
    private ITeamCityClient _client;

    [SetUp]
    public void SetUp()
    {
      _client = new TeamCityClient("teamcity.codebetter.com");
      _client.Connect("teamcitysharpuser", "qwerty");
    }

    [Test]
    public void it_returns_exception_when_no_host_specified()
    {
      Assert.Throws<ArgumentNullException>(() => new TeamCityClient(null));
    }

    [Test]
    public void it_returns_exception_when_host_does_not_exist()
    {
      var client = new TeamCityClient("test:81");
      client.Connect("admin", "qwerty");

      Assert.Throws<WebException>(() => client.VcsRoots.All());
    }

    [Test]
    public void it_returns_exception_when_no_connection_formed()
    {
      var client = new TeamCityClient("teamcity.codebetter.com");
      Assert.Throws<ArgumentException>(() => client.VcsRoots.All());
    }

    [Test]
    public void it_returns_all_vcs_roots()
    {
      List<VcsRoot> vcsRoots = _client.VcsRoots.All();

      Assert.That(vcsRoots.Any(), "No VCS Roots were found for the installation");
    }

    [TestCase("1")]
    public void it_returns_vcs_details_when_passing_vcs_root_id(string vcsRootId)
    {
      VcsRoot rootDetails = _client.VcsRoots.ById(vcsRootId);

      Assert.That(rootDetails != null, "Cannot find the specific VCSRoot");
    }
  }
}