namespace TeamCitySharp.IntegrationTests
{
    using NUnit.Framework;

    [TestFixture]
    [Ignore("These tests are currently not supported by the teamcity.codebetter.com server. Please enable these tests once the server has been upgraded to TeamCity 8.x")]
    public class SampleBuildArtifactUsage
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("teamcity.codebetter.com");
            _client.Connect("teamcitysharpuser", "qwerty");
        }

        [Test]
        public void it_gets_artifacts_for_build()
        {
            const string buildConfigId = "bt248";

            var build = _client.Builds.LastSuccessfulBuildByBuildConfigId(buildConfigId);
            var artifacts = _client.Artifacts.ByBuild(build);

            Assert.That(artifacts.Artifacts.Count > 0, "No artifacts have been found for build");
        }

        [Test]
        public void it_gets_artifacts_for_build_with_relative_name()
        {
            const string buildConfigId = "bt248";

            var build = _client.Builds.LastSuccessfulBuildByBuildConfigId(buildConfigId);
            var artifacts = _client.Artifacts.ByBuild(build, "Ninject.Extensions.bbvEventBroker-3.0.2.6-release-net-4.0.zip");

            Assert.That(artifacts.Artifacts.Count > 0, "No artifacts have been found for build");
        }
    }
}
