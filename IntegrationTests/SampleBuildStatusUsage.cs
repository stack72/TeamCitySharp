using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NUnit.Framework;
using TeamCitySharp;
using TeamCitySharpAPI;
using TeamCitySharpAPI.DomainEntities;
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
            TeamCityBuildStatus client = new Client(null);

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

        [Test]
        public void Get_Last_Successful_Build_By_BuildConfigName()
        {
            string buildConfigName = "Local Debug Build";
            Build buildDetails = _client.GetLastSuccessfulBuildByBuildConfigName(buildConfigName);

            Assert.That(buildDetails != null, "No successful builds have been found");
        }

        [Test]
        public void Get_Successful_Builds_By_BuildConfigName()
        {
            string buildConfigName = "Local Debug Build";
            List<Build> buildDetails = _client.GetSuccessfulBuildsByBuildConfigName(buildConfigName);

            Assert.That(buildDetails.Any(), "No successful builds have been found");
        }

        [Test]
        public void Get_Last_Failed_Build_By_BuildConfigName()
        {
            string buildConfigName = "Local Debug Build";
            Build buildDetails = _client.GetLastFailedBuildByBuildConfigName(buildConfigName);

            Assert.That(buildDetails != null, "No failed builds have been found");
        }

        [Test]
        public void Get_Failed_Builds_By_BuildConfigName()
        {
            string buildConfigName = "Local Debug Build";
            List<Build> buildDetails = _client.GetFailedBuildsByBuildConfigName(buildConfigName);

            Assert.That(buildDetails.Any(), "No failed builds have been found");
        }

        [Test]
        public void Get_Last_Errored_Build_By_BuildConfigName()
        {
            string buildConfigName = "Local Debug Build";
            Build buildDetails = _client.GetLastErrorBuildByBuildConfigName(buildConfigName);

            Assert.That(buildDetails != null, "No errored builds have been found");
        }

        [Test]
        public void Get_Errored_Builds_By_BuildConfigName()
        {
            string buildConfigName = "Local Debug Build";
            List<Build> buildDetails = _client.GetErrorBuildsByBuildConfigName(buildConfigName);

            Assert.That(buildDetails.Any(), "No errored builds have been found");
        }

        [Test]
        public void Get_Last_Build_Status_By_BuildConfigName()
        {
            string buildConfigName = "Local Debug Build";
            Build buildDetails = _client.GetLastBuildStatusByBuildConfigName(buildConfigName);

            Assert.That(buildDetails!=null, "No builds for this build config have been found");
        }

        [Test]
        public void Get_Builds_By_UserName()
        {
            string userName = "admin";
            List<Build> builds = _client.GetBuildsByUserName(userName);

            Assert.That(builds.Any(), "No builds for this user have been found");
        }

        [Test]
        public void Get_NonSuccessful_Builds_By_UserName()
        {
            string userName = "admin";
            List<Build> builds = _client.GetNonSuccessfulBuildsForUser(userName);

            Assert.That(builds.Any(), "No non successful builds found for this user");
        }

        [Test]
        public void Get_NonSuccessful_Build_Count_By_UserName()
        {
            string userName = "admin";
            int builds = _client.GetNonSuccessfulBuildsForUser(userName).Count;

            Assert.That(builds > 0, "No non successful builds found for this user");
        }
    }
}
