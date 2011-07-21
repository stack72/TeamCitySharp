using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NUnit.Framework;
using TeamCitySharpAPI;
using TeamCitySharpAPI.Interfaces;

namespace IntegrationTests
{
    [TestFixture]
    public class SampleBuildStatusUsage
    {
        private TeamCityBuildStatus _client;

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
            TeamCityBuilds client = new Client(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void Instantiating_A_Client_With_A_Host_That_Doesnt_Exist_Throws_Exception()
        {
            TeamCityBuildStatus client = new Client("test:81");
            client.Connect("admin", "qwerty");

            string buildConfigName = "Local Debug Build";
            var builds = client.GetSuccessfulBuildsByBuildConfigName(buildConfigName);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Trying_To_Get_SuccessfulBuilds_WithOut_Connecting_Throws_Exception()
        {
            TeamCityBuildStatus client = new Client("localhost:81");

            string buildConfigName = "Local Debug Build";
            var builds = client.GetSuccessfulBuildsByBuildConfigName(buildConfigName);

            //Assert: Exception
        }
    }
}
