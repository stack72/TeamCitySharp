using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.IntegrationTests
{
    public class when_interacting_to_get_a_build
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("teamcity.codebetter.com");
            _client.Connect("teamcitysharpuser", "qwerty");
        }

        [Test]
        public void it_can_returns_details_on_a_single_build()
        {
            // build http://teamcity.codebetter.com/viewLog.html?buildId=98727&tab=buildResultsDiv&buildTypeId=bt787
            var build = _client.Build.ByBuildLocator(BuildLocator.WithId(98727));

            Assert.That(build, Is.Not.Null);
            Assert.That(build.Id, Is.EqualTo("98727"));
        }
    }
}
