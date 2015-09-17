using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.IntegrationTests
{
    /// <summary>
    /// This class demonstrate sample usage of Investigation methods
    /// </summary>
    [TestFixture]
    public class InvestigationTests
    {
        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("teamcity.codebetter.com");
            _client.Connect("teamcitysharpuser", "qwerty");
        }

        private ITeamCityClient _client;

        [Test]
        public void it_gets_test_investigation_by_name()
        {
            var investigation = _client.Investigations.InvestigationByTest(TestLocator.WithName("full test name"));

        }

        [Test]
        public void it_gets_test_investigation_by_id()
        {
            var investigation = _client.Investigations.InvestigationByTest(TestLocator.WithId("2559068633008576270"));
        }        
        
        [Test]
        public void it_gets_investigations_by_build_configuration()
        {
            var investigations = _client.Investigations.InvestigationsByBuildConfiguration(BuildTypeLocator.WithId("bt936"));
        }

        [Test]
        public void it_gets_investigations_by_user()
        {
            var investigations = _client.Investigations.InvestinationsByUser(UserLocator.WithUserName("borismod"));
        }
    }
}