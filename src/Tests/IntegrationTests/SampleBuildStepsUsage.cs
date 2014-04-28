using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interations_to_get_build_steps
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("teamcity.codebetter.com");
            _client.Connect("teamcitysharpuser", "qwerty");
        }

        [Test]
        public void it_returns_all_build_steps()
        {
            var buildSteps = _client.BuildSteps.ByConfigurationId("bt437");

            Assert.That(buildSteps, Has.Count.GreaterThan(0), "No build steps were found.");
        }
    }
}