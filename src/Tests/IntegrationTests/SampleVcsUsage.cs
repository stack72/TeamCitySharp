using System;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_get_vcs_details
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

            var vcsroots = client.VcsRoots.All();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_returns_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient("teamcity.codebetter.com");

            var vcsRoots = client.VcsRoots.All();

            //Assert: Exception
        }
        
        [Test]
        public void it_returns_all_vcs_roots()
        {
            List<VcsRoot> vcsRoots = _client.VcsRoots.All();

            Assert.That(vcsRoots.Any(), "No VCS Roots were found for the installation");
        }

        [TestCase("1")]
        public void it_returns_vcs_details_when_passing_vcs_root_id(string vcsRootId)
        {
            VcsRoot rootDetails = _client.VcsRoots.ById(vcsRootId);

            Assert.That(rootDetails != null, "Cannot find the specific VCSRoot");
        }

        [TestCase("1")]
        public void it_serializes_vcs_root_to_xml(string vcsRootId)
        {
            VcsRoot rootDetails = _client.VcsRoots.ById(vcsRootId);


            rootDetails.Id += "_new_kii";
            rootDetails.Name+= "_new_kii";

            var vcsRoot = _client.VcsRoots.Create(rootDetails);

            Assert.NotNull(vcsRootId);

            Assert.Equals(vcsRoot.Id, vcsRootId);

        }

        
    }
}