using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_interacting_to_get_change_information
  {
    private ITeamCityClient m_client;
    private readonly string m_server;
    private readonly bool m_useSsl;
    private readonly string m_username;
    private readonly string m_password;
    private readonly string m_goodBuildConfigId;
    private readonly string m_goodProjectId;


    public when_interacting_to_get_change_information()
    {
      m_server = ConfigurationManager.AppSettings["Server"];
      bool.TryParse(ConfigurationManager.AppSettings["UseSsl"], out m_useSsl);
      m_username = ConfigurationManager.AppSettings["Username"];
      m_password = ConfigurationManager.AppSettings["Password"];
      m_goodBuildConfigId = ConfigurationManager.AppSettings["GoodBuildConfigId"];
      m_goodProjectId = ConfigurationManager.AppSettings["GoodProjectId"];
    }
    [SetUp]
    public void SetUp()
    {
      m_client = new TeamCityClient(m_server,m_useSsl);
      m_client.Connect(m_username,m_password);
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

      Assert.Throws<WebException>(() => client.Changes.All());

    }

    [Test]
    public void it_returns_exception_when_no_connection_made()
    {
      var client = new TeamCityClient(m_server, m_useSsl);

      Assert.Throws<ArgumentException>(() => client.Changes.All());
    }

    [Test]
    public void it_returns_all_changes()
    {
      List<Change> changes = m_client.Changes.All();

      Assert.That(changes.Any(), "Cannot find any changes recorded in any of the projects");
    }

    [TestCase("4509768")]
    public void it_returns_change_details_by_change_id(string changeId)
    {
      Change changeDetails = m_client.Changes.ByChangeId(changeId);

      Assert.That(changeDetails != null, "Cannot find details of that specified change");
    }

    [Test]
    public void it_returns_change_details_for_build_config()
    {
      string buildConfigId = m_goodBuildConfigId;
      Change changeDetails = m_client.Changes.LastChangeDetailByBuildConfigId(buildConfigId);

      Assert.That(changeDetails != null, "Cannot find details of that specified change");
    }
  }
}