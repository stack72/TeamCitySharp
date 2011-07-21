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
    public class SampleBuildsUsage
    {
        private TeamCityBuilds _client;

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
            TeamCityBuilds client = new Client("test:81");
            client.Connect("admin", "qwerty");

            var builds = client.GetAllBuildTypes();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Trying_To_Get_Agents_WithOut_Connecting_Throws_Exception()
        {
            TeamCityBuilds client = new Client("localhost:81");

            var builds = client.GetAllBuildTypes();

            //Assert: Exception
        }

        [Test]
        public void Get_List_BuildTypes()
        {
            List<BuildType> buildTypes = _client.GetAllBuildTypes();

            Assert.That(buildTypes.Any(), "No build types were found in this server");
        }

        [Test]
        public void Get_BuildType_By_BuildConfigId()
        {
            string buildConfigId = "bt8";
            BuildType build = _client.GetBuildTypeByBuildConfigurationId(buildConfigId);

            Assert.That(build != null, "Cannot find a build type for that buildId");
        }

        [Test]
        public void Get_BuildType_By_BuildConfigName()
        {
            string buildConfigName = "Local Debug Build";
            BuildType build = _client.GetBuildTypeByBuildConfigurationName(buildConfigName);

            Assert.That(build != null, "Cannot find a build type for that buildName");
        }

        [Test]
        public void Get_BuildType_By_ProjectId()
        {
            string projectId = "project6";
            List<BuildType> builds = _client.GetBuildTypesPerProjectId(projectId);

            Assert.That(builds.Any(), "Cannot find a build type for that projectId");
        }
    }
}