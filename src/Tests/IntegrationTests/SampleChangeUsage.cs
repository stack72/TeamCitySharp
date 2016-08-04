using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_get_change_information
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
        public void it_returns_exception_when_no_host_specified()
        {
            var client = new TeamCityClient(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void it_returns_exception_when_host_does_not_exist()
        {
            var client = new TeamCityClient("test:81");
            client.Connect("admin", "qwerty");

            var changes = client.Changes.All();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_returns_exception_when_no_connection_made()
        {
            var client = new TeamCityClient("teamcity.codebetter.com");

            var changes = client.Changes.All();

            //Assert: Exception
        }

        [Test]
        public void it_returns_all_changes()
        {
            List<Change> changes = _client.Changes.All();

            Assert.That(changes.Any(), "Cannot find any changes recorded in any of the projects");
        }

        [TestCase("42843")]
        public void it_returns_change_details_by_change_id(string changeId)
        {
            Change changeDetails = _client.Changes.ByChangeId(changeId);

            Assert.That(changeDetails != null, "Cannot find details of that specified change");
        }

        [TestCase("104726")]
        public void it_returns_change_details_by_build_id(string buildId)
        {
            var changes = _client.Changes.ByBuildId(buildId);

            Assert.That(changes != null, string.Format("Cannot find any changes for build id {0}", buildId));
        }

        [TestCase("bt113")]
        public void it_returns_change_details_for_build_config(string buildConfigId)
        {
            Change changeDetails = _client.Changes.LastChangeDetailByBuildConfigId(buildConfigId);

            Assert.That(changeDetails != null, "Cannot find details of that specified change");
        }
    }
}