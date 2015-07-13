using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_team_city_client_is_asked_to_return_tests
    {
        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("teamcity.codebetter.com");
            _client.Connect("teamcitysharpuser", "qwerty");
        }

        private ITeamCityClient _client;

        [Test]
        public void it_gets_test_occurrences()
        {
            var createUserResult = _client.TestOccurrences.TestOccurrencesByBuildId(181203, 0, 10);

            Assert.That(createUserResult.Count,Is.EqualTo(10));
        }

        [Test]
        public void it_gets_failed_test_occurrences()
        {
            var createUserResult = _client.TestOccurrences.FailedTestOccurrencesByBuildId(181203, 0, 10);

            Assert.That(createUserResult.Count,Is.EqualTo(0));
        }
    }
}