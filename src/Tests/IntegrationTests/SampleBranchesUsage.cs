using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.IntegrationTests
{
    public class when_interacting_to_get_build_branches
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("teamcity.codebetter.com");
            _client.Connect("teamcitysharpuser", "qwerty");
        }

        [Test]
        public void it_returns_all_branches()
        {
            var branches = _client.Branches.ByBuildLocator(BuildTypeLocator.WithId("bt787" /*git-tfs*/));

            Assert.That(branches.Any(), "Could not get any branches from the tfs-git project.");
        }
    }
}
