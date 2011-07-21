using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NUnit.Framework;
using TeamCitySharpAPI;
using TeamCitySharpAPI.DomainEntities;
using TeamCitySharpAPI.Interfaces;

namespace IntegrationTests
{
    [TestFixture]
    public class SampleProjectUsage
    {
        private TeamCityProjects _client;

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
            TeamCityProjects client = new Client(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void Instantiating_A_Client_With_A_Host_That_Doesnt_Exist_Throws_Exception()
        {
            TeamCityProjects client = new Client("test:81");
            client.Connect("admin", "qwerty");

            var projects = client.GetAllProjects();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Trying_To_Get_Projects_WithOut_Connecting_Throws_Exception()
        {
            TeamCityProjects client = new Client("localhost:81");

            var projects = client.GetAllProjects();

            //Assert: Exception
        }

        [Test]
        public void Get_All_Projects()
        {
            List<Project> projects = _client.GetAllProjects();

            Assert.That(projects.Any(), "No projects were found for this server");
        }

        [Test]
        public void Get_Project_Details_By_ProjectId()
        {
            string projectId = "project6";
            Project projectDetails = _client.GetProjectDetailsByProjectId(projectId);

            Assert.That(projectDetails != null, "No details found for that specific project");
        }

        [Test]
        public void Get_Project_Details_By_ProjectName()
        {
            string projectName = "nPUC";
            Project projectDetails = _client.GetProjectDetailsByProjectName(projectName);

            Assert.That(projectDetails!=null, "No details found for that specific project");
        }
    }
}
