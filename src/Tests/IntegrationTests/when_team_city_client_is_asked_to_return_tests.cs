using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    // ReSharper disable once TestClassNameSuffixWarning
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

        [Test]
        public void it_gets_test_occurences_details()
        {
            List<TestOccurrence> createUserResult = _client.TestOccurrences.TestOccurrencesByBuildId(181203, 0, 10);
            var testOccurrence = _client.TestOccurrences.TestOccurrenceById(createUserResult.First().Id);

            Assert.That(testOccurrence, Is.Not.Null);
        }

        [Test]
        public void it_gets_test_history()
        {
            var client = new TeamCityClient("tc");
            client.Connect("guest", string.Empty);

            var builds = client.Builds.ByBuildConfigId("Trunk_Green_NightlyCi_03TestegatorWebTests");
            List<TestOccurrence> createUserResult = client.TestOccurrences.TestOccurrencesByBuildId(builds.First().Id, 0, 10);
            var testOccurrence = client.TestOccurrences.TestOccurrenceById(createUserResult.First().Id);
            var testHistory = client.TestOccurrences.TestHistoryByTestId(testOccurrence.Test.Id);
            
            Assert.That(testHistory.Count, Is.GreaterThan(0));
        }
    }
}