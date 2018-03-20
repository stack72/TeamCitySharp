using System;
using System.Configuration;
using System.Linq;
using System.Net;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_interations_to_get_build_configuration_details
  {
    private ITeamCityClient m_client;
    private readonly string m_server;
    private readonly bool m_useSsl;
    private readonly string m_username;
    private readonly string m_password;
    private readonly string m_goodBuildConfigId;
    private readonly string m_goodProjectId;


    public when_interations_to_get_build_configuration_details()
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
      client.Connect("teamcitysharpuser", "qwerty");

      Assert.Throws<WebException>(() => client.BuildConfigs.All());
    }

    [Test]
    public void it_throws_exception_when_no_connection_formed()
    {
      var client = new TeamCityClient(m_server,m_useSsl);

      Assert.Throws<ArgumentException>(() => client.BuildConfigs.All());

      //Assert: Exception
    }

    [Test]
    public void it_returns_all_build_types()
    {
      var buildConfigs = m_client.BuildConfigs.All();

      Assert.That(buildConfigs.Any(), "No build types were found in this server");
    }

    [Test]
    public void it_returns_build_config_details_by_configuration_id()
    {
      string buildConfigId = m_goodBuildConfigId;
      var buildConfig = m_client.BuildConfigs.ByConfigurationId(buildConfigId);

      Assert.That(buildConfig != null, "Cannot find a build type for that buildId");
    }

    [Test]
    public void it_pauses_configuration()
    {
      string buildConfigId = m_goodBuildConfigId;
      var buildLocator = BuildTypeLocator.WithId(buildConfigId);
      m_client.BuildConfigs.SetConfigurationPauseStatus(buildLocator, true);
      var status = m_client.BuildConfigs.GetConfigurationPauseStatus(buildLocator);
      Assert.That(status == true, "Build not paused");
    }

    [Test]
    public void it_unpauses_configuration()
    {
      string buildConfigId = m_goodBuildConfigId;
      var buildLocator = BuildTypeLocator.WithId(buildConfigId);
      m_client.BuildConfigs.SetConfigurationPauseStatus(buildLocator, false);
      var status = m_client.BuildConfigs.GetConfigurationPauseStatus(buildLocator);
      Assert.That(status == false, "Build not unpaused");
    }

    [Test]
    public void it_returns_build_config_details_by_configuration_name()
    {
      string buildConfigName = "Release Build";
      var buildConfig = m_client.BuildConfigs.ByConfigurationName(buildConfigName);

      Assert.That(buildConfig != null, "Cannot find a build type for that buildName");
    }

    [Test]
    public void it_returns_build_configs_by_project_id()
    {
      string projectId = m_goodProjectId;
      var buildConfigs = m_client.BuildConfigs.ByProjectId(projectId);

      Assert.That(buildConfigs.Any(), "Cannot find a build type for that projectId");
    }

    [Test]
    public void it_returns_build_configs_by_project_name()
    {
      string projectName = m_goodProjectId;
      var buildConfigs = m_client.BuildConfigs.ByProjectName(projectName);

      Assert.That(buildConfigs.Any(), "Cannot find a build type for that projectName");
    }

    [Test]
    public void it_returns_artifact_dependencies_by_build_config_id()
    {
      string buildConfigId = m_goodBuildConfigId;
      var artifactDependencies = m_client.BuildConfigs.GetArtifactDependencies(buildConfigId);

      Assert.That(artifactDependencies != null, "Cannot find a Artifact dependencies for that buildConfigId");
    }

    [Test]
    public void it_returns_snapshot_dependencies_by_build_config_id()
    {
      string buildConfigId = m_goodBuildConfigId;
      var snapshotDependencies = m_client.BuildConfigs.GetSnapshotDependencies(buildConfigId);
      Assert.That(snapshotDependencies != null, "Cannot find a snapshot dependencies for that buildConfigId");
    }

    [Test]
    public void it_create_build_config_step()
    {
      var bt = m_client.BuildConfigs.CreateConfigurationByProjectId(m_goodProjectId,
        "testNewConfig");
      var xml= "<step type=\"simpleRunner\">" +
               "<properties>" +
               "<property name=\"script.content\" value=\"@echo off&#xA;echo Step1&#xA;touch step1.txt\" />" +
               "<property name=\"teamcity.step.mode\" value=\"default\" />" +
               "<property name=\"use.custom.script\" value=\"true\" />" +
               "</properties>" +
               "</step>";
      m_client.BuildConfigs.PostRawBuildStep(BuildTypeLocator.WithId(bt.Id), xml);
      m_client.BuildConfigs.DeleteConfiguration(BuildTypeLocator.WithId(bt.Id));
    }
  }
}