using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_get_project_details
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new ClientSetup().Connect();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void it_throws_exception_when_not_passing_url()
        {
            var client = new TeamCityClient(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void it_throws_exception_when_host_does_not_exist()
        {
            var client = new TeamCityClient("test:81");
            client.Connect(ClientSetup.TeamCityClientUserName, ClientSetup.TeamCityClientPassword);

            var allProjects = client.AllProjects();             

            //Assert: Exception
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_throws_exception_when_no_connection_formed()
        {
            var client = new TeamCityClient(ClientSetup.TeamCityClientUrl);

            var projects = client.AllProjects();

            //Assert: Exception
        }

        [Test]
        public void it_returns_all_projects()
        {
            List<Project> projects = _client.AllProjects();

            Assert.That(projects.Any(), "No projects were found for this server");
        }

        [Test]
        public void it_returns_project_details_when_passing_a_project_id()
        {
            Project projectDetails = _client.ProjectById(ClientSetup.TestProjectId);

            Assert.That(projectDetails != null, "No details found for that specific project");
        }

        [Test]
        public void it_returns_project_details_when_passing_a_project_name()
        {
            Project projectDetails = _client.ProjectByName(ClientSetup.TestProjectName);

            Assert.That(projectDetails != null, "No details found for that specific project");
        }

        [Test]
        public void it_returns_project_details_when_passing_project()
        {
            var project = new Project { Id = ClientSetup.TestProjectId };
            Project projectDetails = _client.ProjectDetails(project);

            Assert.That(!string.IsNullOrWhiteSpace(projectDetails.Id));
        }
    }
}
