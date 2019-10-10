using System.Configuration;
using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class test_build_artifact_download
  {
    private ITeamCityClient m_client;
    private readonly string m_server;
    private readonly bool m_useSsl;
    private readonly string m_username;
    private readonly string m_password;
    private readonly string m_goodBuildConfigId;

    public test_build_artifact_download()
    {
      m_server = ConfigurationManager.AppSettings["Server"];
      bool.TryParse(ConfigurationManager.AppSettings["UseSsl"], out m_useSsl);
      m_username = ConfigurationManager.AppSettings["Username"];
      m_password = ConfigurationManager.AppSettings["Password"];
      m_goodBuildConfigId = ConfigurationManager.AppSettings["GoodBuildConfigId"];
    }

    [SetUp]
    public void SetUp()
    {
      m_client = new TeamCityClient(m_server, m_useSsl);
      m_client.Connect(m_username, m_password);
    }

    [Test]
    public void it_downloads_artifact()
    {
      string buildConfigId = m_goodBuildConfigId;
      var build = m_client.Builds.LastSuccessfulBuildByBuildConfigId(buildConfigId);
      var directartifact = m_client.Artifacts.ByBuildConfigId(build.BuildTypeId);
      var listFilesDownload = directartifact.Specification(build.Number).Download();
      Assert.IsNotEmpty(listFilesDownload);
    }

    [Test]
    public void it_download_no_artifacts_for_failed_builds()
    {
      string buildConfigId = m_goodBuildConfigId;
      var build= m_client.Builds.LastFailedBuildByBuildConfigId(buildConfigId);
      var directartifact = m_client.Artifacts.ByBuildConfigId(build.BuildTypeId);
      var listFilesDownload = directartifact.Specification(build.Number).Download();
      Assert.IsEmpty(listFilesDownload);
    }
  }
}