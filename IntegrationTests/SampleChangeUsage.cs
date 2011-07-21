using System;
using System.Linq;
using System.Net;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Instantiating_A_Client_Without_Host_Throws_Exception()
        {
            TeamCityChanges client = new Client(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void Instantiating_A_Client_With_A_Host_That_Doesnt_Exist_Throws_Exception()
        {
            TeamCityChanges client = new Client("test:81");
            client.Connect("admin", "qwerty");

            var changes = client.GetAllChanges();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Trying_To_Get_Changes_WithOut_Connecting_Throws_Exception()
        {
            TeamCityChanges client = new Client("localhost:81");

            var changes = client.GetAllChanges();

            //Assert: Exception
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