using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using TeamCitySharp.Connection;
using TeamCitySharp.Fields;
using TeamCitySharp.Locators;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_interacting_to_get_test
  {
    private ITeamCityClient m_client;
    private readonly string m_server;
    private readonly bool m_useSsl;
    private readonly string m_username;
    private readonly string m_password;
    private readonly int m_goodBuildId;
    private readonly string m_goodProjectId;
    private readonly string m_goodTestId;


    public when_interacting_to_get_test()
    {
      m_server = ConfigurationManager.AppSettings["Server"];
      bool.TryParse(ConfigurationManager.AppSettings["UseSsl"], out m_useSsl);
      m_username = ConfigurationManager.AppSettings["Username"];
      m_password = ConfigurationManager.AppSettings["Password"];
      int.TryParse(ConfigurationManager.AppSettings["GoodBuildId"], out m_goodBuildId);
      m_goodProjectId = ConfigurationManager.AppSettings["GoodProjectId"];
      m_goodTestId = ConfigurationManager.AppSettings["GoodTestId"];
    }

    [SetUp]
    public void SetUp()
    {
      m_client = new TeamCityClient(m_server, m_useSsl);
      m_client.Connect(m_username, m_password);
    }

    [Test]
    public void it_throws_exception_when_no_url_passed()
    {
      Assert.Throws<ArgumentNullException>(() => new TeamCityClient(null));
    }

    [Test]
    public void it_returns_tests_for_all_running_builds()
    {
      var result = m_client.Tests.ByBuildLocator(BuildLocator.WithId(m_goodBuildId));
      Assert.IsNotEmpty(result.TestOccurrence);
    }

    [Test]
    public void it_returns_currently_failling_tests_for_project()
    {
      var result = m_client.Tests.ByProjectLocator(ProjectLocator.WithId(m_goodProjectId));
      Assert.IsNotEmpty(result.TestOccurrence);
    }

    [Test]
    public void it_returns_test_occurrences_for_test()
    {
      var result = m_client.Tests.ByTestLocator(TestLocator.WithId(m_goodTestId));
      Assert.IsNotEmpty(result.TestOccurrence);
    }

    [Test]
    public void it_returns_all_tests_for_all_running_builds()
    {
      var result = m_client.Tests.All(BuildLocator.WithId(m_goodBuildId));
      Assert.IsNotEmpty(result);
    }

    [Test]
    public void it_returns_all_currently_failling_tests_for_project()
    {
      var result = m_client.Tests.All(ProjectLocator.WithId(m_goodProjectId));
      Assert.IsNotEmpty(result);
    }

    [Test]
    public void it_returns_all_test_occurrences_for_test()
    {
      var result = m_client.Tests.All(TestLocator.WithId(m_goodTestId));
      Assert.IsNotEmpty(result);
    }
  }
}