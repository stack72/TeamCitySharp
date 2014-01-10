using System;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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
            new TeamCityClient(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void it_throws_exception_when_host_does_not_exist()
        {
            var client = new TeamCityClient("test:81");
            client.Connect("admin", "qwerty");

            const string buildConfigId = "Release Build";
            client.Builds.SuccessfulBuildsByBuildConfigId(buildConfigId);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_throws_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient("teamcity.codebetter.com");

            const string buildConfigId = "Release Build";
            client.Builds.SuccessfulBuildsByBuildConfigId(buildConfigId);

            //Assert: Exception
        }

        [Test]
        public void it_returns_last_successful_build_by_build_config_id()
        {
            const string buildConfigId = "bt437";
            var build = _client.Builds.LastSuccessfulBuildByBuildConfigId(buildConfigId);

            Assert.That(build != null, "No successful builds have been found");
        }

        [Test]
        public void it_returns_last_successful_builds_by_build_config_id()
        {
            const string buildConfigId = "bt437";
            var buildDetails = _client.Builds.SuccessfulBuildsByBuildConfigId(buildConfigId);

            Assert.That(buildDetails.Any(), "No successful builds have been found");
        }

        [Test]
        public void it_returns_last_failed_build_by_build_config_id()
        {
            const string buildConfigId = "bt437";
            var buildDetails = _client.Builds.LastFailedBuildByBuildConfigId(buildConfigId);

            Assert.That(buildDetails != null, "No failed builds have been found");
        }

        [Test]
        public void it_returns_all_non_successful_builds_by_config_id()
        {
            const string buildConfigId = "bt437";
            var builds = _client.Builds.FailedBuildsByBuildConfigId(buildConfigId);

            Assert.That(builds.Any(), "No failed builds have been found");
        }

        [Test]
        public void it_returns_last_error_build_by_config_id()
        {
            const string buildConfigId = "bt437";
            var buildDetails = _client.Builds.LastErrorBuildByBuildConfigId(buildConfigId);

            Assert.That(buildDetails != null, "No errored builds have been found");
        }

        [Test]
        public void it_returns_all_error_builds_by_config_id()
        {
            const string buildId = "bt437";
            var builds = _client.Builds.ErrorBuildsByBuildConfigId(buildId);

            Assert.That(builds.Any(), "No errored builds have been found");
        }

        [Test]
        public void it_returns_the_last_build_status_by_build_config_id()
        {
            const string buildConfigId = "bt437";
            var build = _client.Builds.LastBuildByBuildConfigId(buildConfigId);

            Assert.That(build != null, "No builds for this build config have been found");
        }

        [Test]
        public void it_returns_all_builds_by_build_config_id()
        {
            const string buildConfigId = "bt437";
            var builds = _client.Builds.ByBuildConfigId(buildConfigId);

            Assert.That(builds.Any(), "No builds for this build configuration have been found");
        }

        [Test]
        public void it_returns_all_builds_by_build_config_id_and_tag()
        {
            const string buildConfigId = "bt437";
            const string tag = "Release";
            var builds = _client.Builds.ByConfigIdAndTag(buildConfigId, tag);

            Assert.IsNotNull(builds, "No builds were found for this build id and Tag");
        }

        [Test]
        public void it_returns_all_builds_by_username()
        {
            const string userName = "teamcitysharpuser";
            var builds = _client.Builds.ByUserName(userName);

            Assert.IsNotNull(builds, "No builds for this user have been found");
        }

        [Test]
        public void it_returns_all_non_successful_builds_by_username()
        {
            const string userName = "teamcitysharpuser";
            var builds = _client.Builds.NonSuccessfulBuildsForUser(userName);

            Assert.IsNotNull(builds, "No non successful builds found for this user");
        }

        [Test]
        public void it_returns_all_non_successful_build_count_by_username()
        {
            const string userName = "teamcitysharpuser";
            var builds = _client.Builds.NonSuccessfulBuildsForUser(userName);

            Assert.IsNotNull(builds, "No non successful builds found for this user");
        }

        [Test]
        public void it_returns_all_running_builds()
        {
            var builds = _client.Builds.ByBuildLocator(BuildLocator.RunningBuilds());

            Assert.IsNotNull(builds, "There are currently no running builds");
        }

        [Test]
        public void it_returns_all_successful_builds_since_date()
        {
            var builds = _client.Builds.AllBuildsOfStatusSinceDate(DateTime.Now.AddDays(-2), BuildStatus.FAILURE);

            Assert.IsNotNull(builds);
        }

        [Test]
        public void it_does_not_populate_the_status_text_field_of_the_build_object()
        {
            const string buildConfigId = "bt5";
            var client = new TeamCityClient("localhost:81");
            client.Connect("admin", "qwerty");

            var build =
                client.Builds.ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                         maxResults: 1));
            Assert.That(build.Count == 1);
            Assert.IsNull(build[0].StatusText);
        }

        [Test]
        public void ig_returns_correct_build_when_calling_by_id()
        {
            const string buildId = "5726";
            var client = new TeamCityClient("localhost:81");
            client.Connect("admin", "qwerty");

            var build = client.Builds.ById(buildId);

            Assert.That(build != null);
            Assert.That(build.Id == buildId);
        }
    }
}
