using System;
using System.Linq;
using System.Net;
using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interations_to_get_build_configuration_details
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

            var builds = client.AllBuildConfigs();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_throws_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient("localhost:81");

            var builds = client.AllBuildConfigs();

            //Assert: Exception
        }

        [Test]
        public void it_returns_all_build_types()
        {
            var buildTypes = _client.AllBuildConfigs();

            Assert.That(buildTypes.Any(), "No build types were found in this server");
        }

        [Test]
        public void it_returns_build_config_details_by_configuration_id()
        {
            string buildConfigId = "bt8";
            var buildType = _client.BuildConfigByConfigurationId(buildConfigId);

            Assert.That(buildType != null, "Cannot find a build type for that buildId");
        }

        [Test]
        public void it_returns_build_config_details_by_configuration_name()
        {
            string buildConfigName = "Local Debug Build";
            var buildType = _client.BuildConfigByConfigurationName(buildConfigName);

            Assert.That(buildType != null, "Cannot find a build type for that buildName");
        }

        [Test]
        public void it_returns_build_configs_by_project_id()
        {
            string projectId = "project6";
            var buildTypes = _client.BuildConfigsByProjectId(projectId);

            Assert.That(buildTypes.Any(), "Cannot find a build type for that projectId");
        }
    }
}