using System;
using System.Linq;
using System.Net;
using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_get_build_status_info
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new ClientSetup().Connect();
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
            client.Connect(ClientSetup.TeamCityClientUserName, ClientSetup.TeamCityClientPassword);

            string buildConfigId = "Local Debug Build";
            var builds = client.SuccessfulBuildsByBuildConfigId(buildConfigId);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_throws_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient(ClientSetup.TeamCityClientUrl);

            string buildConfigId = "Local Debug Build";
            var builds = client.SuccessfulBuildsByBuildConfigId(buildConfigId);

            //Assert: Exception
        }

        [Test]
        public void it_returns_last_successful_build_by_build_config_id()
        {
            var build = _client.LastSuccessfulBuildByBuildConfigId(ClientSetup.TestBuildConfigId);

            Assert.That(build != null, "No successful builds have been found");
        }

        [Test]
        public void it_returns_last_successful_builds_by_build_config_id()
        {
            var buildDetails = _client.SuccessfulBuildsByBuildConfigId(ClientSetup.TestBuildConfigId);

            Assert.That(buildDetails.Any(), "No successful builds have been found");
        }

        [Test]
        public void it_returns_last_failed_build_by_build_config_id()
        {
            var buildDetails = _client.LastFailedBuildByBuildConfigId(ClientSetup.TestBuildConfigId);

            Assert.That(buildDetails != null, "No failed builds have been found");
        }

        [Test]
        public void it_returns_all_non_successful_builds_by_config_id()
        {
            var builds = _client.FailedBuildsByBuildConfigId(ClientSetup.TestBuildConfigId);

            Assert.That(builds.Any(), "No failed builds have been found");
        }

        [Test]
        public void it_returns_last_error_build_by_config_id()
        {
            var buildDetails = _client.LastErrorBuildByBuildConfigId(ClientSetup.TestBuildConfigId);

            Assert.That(buildDetails != null, "No errored builds have been found");
        }

        [Test]
        public void it_returns_all_error_builds_by_config_id()
        {
            var builds = _client.ErrorBuildsByBuildConfigId(ClientSetup.TestBuildConfigId);

            Assert.That(builds.Any(), "No errored builds have been found");
        }

        [Test]
        public void it_returns_the_last_build_status_by_build_config_id()
        {
            var build = _client.LastBuildByBuildConfigId(ClientSetup.TestBuildConfigId);

            Assert.That(build != null, "No builds for this build config have been found");
        }

        [Test]
        public void it_returns_all_builds_by_build_config_id()
        {
            var builds = _client.BuildConfigsByBuildConfigId(ClientSetup.TestBuildConfigId);

            Assert.That(builds.Any(), "No builds for this build configuration have been found");
        }

        [Test]
        public void it_returns_all_builds_by_build_config_id_and_tag()
        {
            var builds = _client.BuildConfigsByConfigIdAndTag(ClientSetup.TestBuildConfigId, ClientSetup.TestTag);

            Assert.That(builds.Any(), "No builds were found for this build id and Tag");
        }

        [Test]
        public void it_returns_all_builds_by_username()
        {
            var builds = _client.BuildsByUserName(ClientSetup.TeamCityClientUserName);

            Assert.That(builds.Any(), "No builds for this user have been found");
        }

        [Test]
        public void it_returns_all_non_successful_builds_by_username()
        {
            var builds = _client.NonSuccessfulBuildsForUser(ClientSetup.TeamCityClientUserName);

            Assert.That(builds.Any(), "No non successful builds found for this user");
        }

        [Test]
        public void it_returns_all_non_successful_build_count_by_username()
        {
            int builds = _client.NonSuccessfulBuildsForUser(ClientSetup.TeamCityClientUserName).Count;

            Assert.That(builds > 0, "No non successful builds found for this user");
        }

        [Test]
        public void it_returns_all_running_builds()
        {
            var builds = _client.BuildsByBuildLocator(BuildLocator.RunningBuilds());

            Assert.That(builds.Any(), "There are currently no running builds");
        }
    }
}
