using System;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
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
            _client = new ClientSetup().Connect();
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
            client.Connect(ClientSetup.TeamCityClientUserName, ClientSetup.TeamCityClientPassword);

            var vcsroots = client.AllVcsRoots();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_returns_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient(ClientSetup.TeamCityClientUrl);

            var vcsRoots = client.AllVcsRoots();

            //Assert: Exception
        }
        
        [Test]
        public void it_returns_all_vcs_roots()
        {
            List<VcsRoot> vcsRoots = _client.AllVcsRoots();

            Assert.That(vcsRoots.Any(), "No VCS Roots were found for the installation");
        }

        [Test]
        public void it_returns_vcs_details_when_passing_vcs_root_id()
        {
            VcsRoot rootDetails = _client.VcsRootById(ClientSetup.TestVcsRootId);

            Assert.That(rootDetails != null, "Cannot find the specific VCSRoot");
        }
    }
}