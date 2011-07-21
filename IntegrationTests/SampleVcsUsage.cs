using NUnit.Framework;
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