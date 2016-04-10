using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using TeamCitySharp.ActionTypes;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interations_to_get_build_configuration_details
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("teamcity.codebetter.com");
            _client.Connect("teamcitysharpuser", "qwerty");
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
            client.Connect("teamcitysharpuser", "qwerty");

            var builds = client.BuildConfigs.All();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_throws_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient("teamcity.codebetter.com");

            var builds = client.BuildConfigs.All();

            //Assert: Exception
        }

        [Test]
        public void it_returns_all_build_types()
        {
            var buildConfigs = _client.BuildConfigs.All();

            Assert.That(buildConfigs.Any(), "No build types were found in this server");
        }

        [Test]
        public void it_returns_build_config_details_by_configuration_id()
        {
            string buildConfigId = "bt437";
            var buildConfig = _client.BuildConfigs.ByConfigurationId(buildConfigId);

            Assert.That(buildConfig != null, "Cannot find a build type for that buildId");
        }

        [Test]
        public void it_pauses_configuration()
        {
            string buildConfigId = "bt437";
            var buildLocator = BuildTypeLocator.WithId(buildConfigId);
            _client.BuildConfigs.SetConfigurationPauseStatus(buildLocator, true);
            var status = _client.BuildConfigs.GetConfigurationPauseStatus(buildLocator);
            Assert.That(status == true, "Build not paused");
        }

        [Test]
        public void it_unpauses_configuration()
        {
            string buildConfigId = "bt437";
            var buildLocator = BuildTypeLocator.WithId(buildConfigId);
            _client.BuildConfigs.SetConfigurationPauseStatus(buildLocator, false);
            var status = _client.BuildConfigs.GetConfigurationPauseStatus(buildLocator);
            Assert.That(status == false, "Build not unpaused");
        }

        [Test]
        public void it_returns_build_config_details_by_configuration_name()
        {
            string buildConfigName = "Release Build";
            var buildConfig = _client.BuildConfigs.ByConfigurationName(buildConfigName);

            Assert.That(buildConfig != null, "Cannot find a build type for that buildName");
        }

        [Test]
        public void it_returns_build_configs_by_project_id()
        {
            string projectId = "project137";
            var buildConfigs = _client.BuildConfigs.ByProjectId(projectId);

            Assert.That(buildConfigs.Any(), "Cannot find a build type for that projectId");
        }

        [Test]
        public void it_returns_build_configs_by_project_name()
        {
            string projectName = "YouTrackSharp";
            var buildConfigs = _client.BuildConfigs.ByProjectName(projectName);

            Assert.That(buildConfigs.Any(), "Cannot find a build type for that projectName");
        }      
        
        [Test]
        public void it_copies_build_configuration()
        {
            var client = CreateTeamCityClient();

            var buildConfig = client.BuildConfigs.CopyBuildConfiguration(BuildTypeLocator.WithId("Misc_Playground"), ProjectLocator.WithId("Misc_Tryout"), "Misc Playground Copied");
            client.BuildConfigs.DeleteConfiguration(BuildTypeLocator.WithId(buildConfig.Id));

            Assert.That(buildConfig.Name, Is.EqualTo("Misc Playground Copied"));
        }

        [Test]
        public void it_creates_build_configuration_and_attaches_tp_template()
        {
            var client = CreateTeamCityClient();

            var buildConfig = client.BuildConfigs.CreateConfiguration(ProjectLocator.WithId("Misc_Tryout"), "Misc Playground Copied");
            client.BuildConfigs.AttachToTemplate(BuildTypeLocator.WithId(buildConfig.Id), "Misc_Tryout_PlaygroundTemplate");
            client.BuildConfigs.DeleteConfiguration(BuildTypeLocator.WithId(buildConfig.Id));

            Assert.That(buildConfig.Name, Is.EqualTo("Misc Playground Copied"));
        }

        [Test]
        public void it_triggers_build_configuration()
        {
            _client.BuildConfigs.TriggerBuildConfiguration("Misc_Playground"); 
        }        
        
        [Test]
        public void it_updates_build_configuration_name()
        {
            var teamCityClient = CreateTeamCityClient();
            teamCityClient.BuildConfigs.UpdateName(BuildTypeLocator.WithId("Misc_Playground"), "The new playground"); 
        }

        [Test]
        public void it_triggers_build_configuration_sends_parametes()
        {
            var client = CreateTeamCityClient();
            client.BuildConfigs.TriggerBuildConfiguration("Misc_Tryout_02GeneralTestsAnalyzer", new[]
            {
                new Property { Name = "build.vcs.number", Value = "139209"}
            });
        }

        private ITeamCityClient CreateTeamCityClient()
        {
            return _client;
        }
    }
}