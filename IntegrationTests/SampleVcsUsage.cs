using System;
using System.Net;
using NUnit.Framework;
using TeamCitySharp;
using TeamCitySharpAPI;
using TeamCitySharpAPI.DomainEntities;
using TeamCitySharpAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationTests
{
    [TestFixture]
    public class SampleVcsUsage
    {
        private TeamCityVcsRoots _client;

        [SetUp]
        public void SetUp()
        {
            _client = new Client("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Instantiating_A_Client_Without_Host_Throws_Exception()
        {
            TeamCityVcsRoots client = new Client(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void Instantiating_A_Client_With_A_Host_That_Doesnt_Exist_Throws_Exception()
        {
            TeamCityVcsRoots client = new Client("test:81");
            client.Connect("admin", "qwerty");

            var vcsroots = client.GetAllVcsRoots();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Trying_To_Get_VcsRoots_WithOut_Connecting_Throws_Exception()
        {
            TeamCityVcsRoots client = new Client("localhost:81");

            var vcsRoots = client.GetAllVcsRoots();

            //Assert: Exception
        }
        
        [Test]
        public void Get_All_VCSRoots()
        {
            List<VcsRoot> vcsRoots = _client.GetAllVcsRoots();

            Assert.That(vcsRoots.Any(), "No VCS Roots were found for the installation");
        }

        [Test]
        public void Get_VCSRoot_Details_By_VCSRoot_Id()
        {
            var vcsRootID = "1";
            VcsRoot rootDetails = _client.GetVcsRootById(vcsRootID);

            Assert.That(rootDetails != null, "Cannot find the specific VCSRoot");
        }
    }
}