using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TeamCitySharp.DomainEntities;

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
            List<Investigation> investigations = _client.Investigations.InvestigationsByName("full test name");
            var investigation = investigations.Single();

        }

        [Test]
        public void it_gets_test_investigation_by_id()
        {
            List<Investigation> investigations = _client.Investigations.InvestigationsById("2559068633008576270");

            var investigation = investigations.Single();

        }
    }
}