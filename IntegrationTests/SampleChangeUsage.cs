using System.Linq;
using NUnit.Framework;
using TeamCitySharpAPI;
using TeamCitySharpAPI.DomainEntities;
using TeamCitySharpAPI.Interfaces;
using System.Collections.Generic;

namespace IntegrationTests
{
    [TestFixture]
    public class SampleChangeUsage
    {
        private TeamCityChanges _client;

        [SetUp]
        public void SetUp()
        {
            _client = new Client("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        [Test]
        public void Get_All_Changes()
        {
            List<Change> changes = _client.GetAllChanges();

            Assert.That(changes.Any(), "Cannot find any changes recorded in any of the projects");
        }

        [Test]
        public void Get_Change_Details_By_Change_Id()
        {
            string changeId = "102";
            Change changeDetails = _client.GetChangeDetailsByChangeId(changeId);

            Assert.That(changeDetails != null, "Cannot find details of that specified change");
        }
    }
}