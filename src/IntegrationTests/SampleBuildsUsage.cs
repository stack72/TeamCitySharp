using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_get_build_status_info
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
            client.Connect("admin", "qwerty");

            string buildConfigId = "Release Build";
            var builds = client.SuccessfulBuildsByBuildConfigId(buildConfigId);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_throws_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient("teamcity.codebetter.com");

            string buildConfigId = "Release Build";
            var builds = client.SuccessfulBuildsByBuildConfigId(buildConfigId);

            //Assert: Exception
        }

        [Test]
        public void it_returns_last_successful_build_by_build_config_id()
        {
            string buildConfigId = "bt437";
            var build = _client.LastSuccessfulBuildByBuildConfigId(buildConfigId);

            Assert.That(build != null, "No successful builds have been found");
        }

        [Test]
        public void it_returns_last_successful_builds_by_build_config_id()
        {
            string buildConfigId = "bt437";
            var buildDetails = _client.SuccessfulBuildsByBuildConfigId(buildConfigId);

            Assert.That(buildDetails.Any(), "No successful builds have been found");
        }

        [Test]
        public void it_returns_last_failed_build_by_build_config_id()
        {
            string buildConfigId = "bt437";
            var buildDetails = _client.LastFailedBuildByBuildConfigId(buildConfigId);

            Assert.That(buildDetails != null, "No failed builds have been found");
        }

        [Test]
        public void it_returns_all_non_successful_builds_by_config_id()
        {
            string buildConfigId = "bt437";
            var builds = _client.FailedBuildsByBuildConfigId(buildConfigId);

            Assert.That(builds.Any(), "No failed builds have been found");
        }

        [Test]
        public void it_returns_last_error_build_by_config_id()
        {
            string buildConfigId = "bt437";
            var buildDetails = _client.LastErrorBuildByBuildConfigId(buildConfigId);

            Assert.That(buildDetails != null, "No errored builds have been found");
        }

        [Test]
        public void it_returns_all_error_builds_by_config_id()
        {
            string buildId = "bt437";
            var builds = _client.ErrorBuildsByBuildConfigId(buildId);

            Assert.That(builds.Any(), "No errored builds have been found");
        }

        [Test]
        public void it_returns_the_last_build_status_by_build_config_id()
        {
            string buildConfigId = "bt437";
            var build = _client.LastBuildByBuildConfigId(buildConfigId);

            Assert.That(build != null, "No builds for this build config have been found");
        }

        [Test]
        public void it_returns_all_builds_by_build_config_id()
        {
            string buildConfigId = "bt437";
            var builds = _client.BuildConfigsByBuildConfigId(buildConfigId);

            Assert.That(builds.Any(), "No builds for this build configuration have been found");
        }

        [Test]
        public void it_returns_all_builds_by_build_config_id_and_tag()
        {
            string buildConfigId = "bt437";
            string tag = "test";
            var builds = _client.BuildConfigsByConfigIdAndTags(buildConfigId, tag);

            Assert.IsNotNull(builds, "No builds were found for this build id and Tag");
        }

        [Test]
        public void it_returns_all_builds_by_username()
        {
            string userName = "teamcitysharpuser";
            var builds = _client.BuildsByUserName(userName);

            Assert.IsNotNull(builds, "No builds for this user have been found");
        }

        [Test]
        public void it_returns_all_non_successful_builds_by_username()
        {
            string userName = "teamcitysharpuser";
            var builds = _client.NonSuccessfulBuildsForUser(userName);

            Assert.IsNotNull(builds, "No non successful builds found for this user");
        }

        [Test]
        public void it_returns_all_non_successful_build_count_by_username()
        {
            string userName = "teamcitysharpuser";
            var builds = _client.NonSuccessfulBuildsForUser(userName);

            Assert.IsNotNull(builds, "No non successful builds found for this user");
        }

        [Test]
        public void it_returns_all_running_builds()
        {
			var builds = _client.RunningBuilds();
            Assert.IsNotNull(builds, "There are currently no running builds");
        }

        [Test] 
        public void it_returns_all_successful_builds_since_date()
        {
            var builds = _client.AllBuildsOfStatusSinceDate(DateTime.Now.AddDays(-2), BuildStatus.FAILURE);

            Assert.IsNotNull(builds);
        }
    }
}
