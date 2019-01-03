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
  public class when_interacting_to_get_build_status_info
  {
    private ITeamCityClient m_client;
    private readonly string m_server;
    private readonly bool m_useSsl;
    private readonly string m_username;
    private readonly string m_password;
    private readonly string m_goodBuildConfigId;
    private readonly string m_goodProjectId;
    private readonly string m_goodNumber;


    public when_interacting_to_get_build_status_info()
    {
      m_server = ConfigurationManager.AppSettings["Server"];
      bool.TryParse(ConfigurationManager.AppSettings["UseSsl"], out m_useSsl);
      m_username = ConfigurationManager.AppSettings["Username"];
      m_password = ConfigurationManager.AppSettings["Password"];
      m_goodBuildConfigId = ConfigurationManager.AppSettings["GoodBuildConfigId"];
      m_goodProjectId = ConfigurationManager.AppSettings["GoodProjectId"];
      m_goodNumber = ConfigurationManager.AppSettings["GoodNumber"];
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
    public void it_throws_exception_when_host_does_not_exist()
    {
      var client = new TeamCityClient("test:81");
      client.Connect("admin", "qwerty");

      const string buildConfigId = "Release Build";
      Assert.Throws<HttpRequestException>(() => client.Builds.SuccessfulBuildsByBuildConfigId(buildConfigId));
    }

    [Test]
    public void it_throws_exception_when_no_connection_formed()
    {
      var client = new TeamCityClient(m_server, m_useSsl);

      const string buildConfigId = "Release Build";
      Assert.Throws<ArgumentException>(() => client.Builds.SuccessfulBuildsByBuildConfigId(buildConfigId));
    }

    [Test]
    public void it_returns_last_successful_build_by_build_config_id()
    {
      string buildConfigId = m_goodBuildConfigId;
      var build = m_client.Builds.LastSuccessfulBuildByBuildConfigId(buildConfigId);

      Assert.That(build != null, "No successful builds have been found");
    }

    [Test]
    public void it_returns_last_successful_builds_by_build_config_id()
    {
      string buildConfigId = m_goodBuildConfigId;
      var buildDetails = m_client.Builds.SuccessfulBuildsByBuildConfigId(buildConfigId);

      Assert.That(buildDetails.Any(), "No successful builds have been found");
    }

    [Test]
    public void it_returns_last_failed_build_by_build_config_id()
    {
      string buildConfigId = m_goodBuildConfigId;
      var buildDetails = m_client.Builds.LastFailedBuildByBuildConfigId(buildConfigId);

      Assert.That(buildDetails != null, "No failed builds have been found");
    }

    [Test]
    public void it_returns_all_non_successful_builds_by_config_id()
    {
      string buildConfigId = m_goodBuildConfigId;
      var builds = m_client.Builds.FailedBuildsByBuildConfigId(buildConfigId);

      Assert.That(builds.Any(), "No failed builds have been found");
    }

    [Test]
    public void it_doesnt_throw_exceptions_when_searching_last_error_build_by_config_id()
    {
      try
      {
        m_client.Builds.LastErrorBuildByBuildConfigId(m_goodBuildConfigId);
      }
      catch (Exception e)
      {
        Assert.Fail($"Accessing last error build for config {m_goodBuildConfigId} raised an exception", e);
      }
    }

    [Test]
    public void it_returns_the_last_build_status_by_build_config_id()
    {
      string buildConfigId = m_goodBuildConfigId;
      var build = m_client.Builds.LastBuildByBuildConfigId(buildConfigId);

      Assert.That(build != null, "No builds for this build config have been found");
    }

    [Test]
    public void it_returns_all_builds_by_build_config_id()
    {
      string buildConfigId = m_goodBuildConfigId;
      var builds = m_client.Builds.ByBuildConfigId(buildConfigId);

      Assert.That(builds.Any(), "No builds for this build configuration have been found");
    }

    [Test]
    public void it_returns_all_builds_by_build_config_id_and_tag()
    {
      string buildConfigId = m_goodBuildConfigId;
      const string tag = "Release";
      var builds = m_client.Builds.ByConfigIdAndTag(buildConfigId, tag);

      Assert.IsNotNull(builds, "No builds were found for this build id and Tag");
    }

    [Test]
    public void it_returns_all_builds_by_username()
    {
      string userName = m_username;
      var builds = m_client.Builds.ByUserName(userName);

      Assert.IsNotNull(builds, "No builds for this user have been found");
    }

    [Test]
    public void it_returns_all_non_successful_builds_by_username()
    {
      string userName = m_username;
      var builds = m_client.Builds.NonSuccessfulBuildsForUser(userName);

      Assert.IsNotNull(builds, "No non successful builds found for this user");
    }

    [Test]
    public void it_returns_all_non_successful_build_count_by_username()
    {
      string userName = m_username;
      var builds = m_client.Builds.NonSuccessfulBuildsForUser(userName);

      Assert.IsNotNull(builds, "No non successful builds found for this user");
    }

    [Test]
    public void it_returns_all_running_builds()
    {
      var builds = m_client.Builds.ByBuildLocator(BuildLocator.RunningBuilds());

      Assert.IsNotNull(builds, "There are currently no running builds");
    }

    [Test]
    public void it_returns_all_successful_builds_since_date()
    {
      var builds = m_client.Builds.AllBuildsOfStatusSinceDate(DateTime.Now.AddDays(-2), BuildStatus.FAILURE);

      Assert.IsNotNull(builds);
    }

    [Test]
    public void it_does_not_populate_the_status_text_field_of_the_build_object()
    {
      string buildConfigId = m_goodBuildConfigId;
      var client = new TeamCityClient(m_server, m_useSsl);
      client.ConnectAsGuest();

      var build =
          client.Builds.ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
              maxResults: 1));
      Assert.That(build.Count == 1);
      Assert.IsNull(build[0].StatusText);
    }

    [Test]
    public void unknown_build_id_raises_exception()
    {
      const string buildId = "5726";
      try
      {
        m_client.Builds.ById(buildId);
      }
      catch (HttpException e)
      {
        Assert.That(e.ResponseStatusCode == HttpStatusCode.NotFound, "Expects a 404 exception.");
      }
      catch (Exception e)
      {
        Assert.Fail($"Fetching a build by id for {buildId} raised an unexpected exception", e);
      }
    }

    [Test]
    public void it_returns_correct_next_builds()
    {
      const string buildId = "5726";
      var client = new TeamCityClient(m_server, m_useSsl);
      client.ConnectAsGuest();

      var builds = client.Builds.NextBuilds(buildId, 10);

      foreach (var build in builds)
      {
        Console.WriteLine($"Build: {build}");
      }

      Assert.That(builds != null);
      Assert.That(builds.Count == 10);
    }

    [Test]
    public void it_returns_correct_next_builds_with_filter()
    {
      const string buildId = "5726";
      var client = new TeamCityClient(m_server, m_useSsl);
      client.ConnectAsGuest();

      BuildField buildField = BuildField.WithFields(id: true, number: true, finishDate: true);
      BuildsField buildsField = BuildsField.WithFields(buildField);
      var builds = client.Builds.GetFields(buildsField.ToString()).NextBuilds(buildId, 10);

      Assert.That(builds != null);
      Assert.That(builds.Count == 10);
      int i = 0;
      foreach (var build in builds)
      {
        Assert.That(build.FinishDate != new DateTime());
        Console.WriteLine("{0} => BuildId => {1} FinishDate => {2}", i, build.Id, build.FinishDate);
        i++;
      }
    }

    [Test, Ignore("m_goodNumber is not pointing to a valid number anymore.")]
    public void it_pin_by_config()
    {
      m_client.Builds.PinBuildByBuildNumber(m_goodBuildConfigId, m_goodNumber, "Automated Comment");
    }

    [Test, Ignore("m_goodNumber is not pointing to a valid number anymore.")]
    public void it_unpin_by_config()
    {
      m_client.Builds.UnPinBuildByBuildNumber(m_goodBuildConfigId, m_goodNumber);
    }
  }
}