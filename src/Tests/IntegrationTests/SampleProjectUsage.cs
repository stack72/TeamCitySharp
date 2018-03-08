using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using NUnit.Framework;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_interacting_to_get_project_details
  {
    private ITeamCityClient m_client;
    private readonly string m_server;
    private readonly bool m_useSsl;
    private readonly string m_username;
    private readonly string m_password;
    private readonly string m_goodBuildConfigId;
    private readonly string m_goodProjectId;


    public when_interacting_to_get_project_details()
    {
      m_server = ConfigurationManager.AppSettings["Server"];
      bool.TryParse(ConfigurationManager.AppSettings["UseSsl"], out m_useSsl);
      m_username = ConfigurationManager.AppSettings["Username"];
      m_password = ConfigurationManager.AppSettings["Password"];
      m_goodBuildConfigId = ConfigurationManager.AppSettings["GoodBuildConfigId"];
      m_goodProjectId = ConfigurationManager.AppSettings["GoodProjectId"];
    }
    [SetUp]
    public void SetUp()
    {
      m_client = new TeamCityClient(m_server, m_useSsl);
      m_client.Connect(m_username, m_password);
    }

    [Test]
    public void it_throws_exception_when_not_passing_url()
    {
      Assert.Throws<ArgumentNullException>(() => new TeamCityClient(null));
    }

    [Test]
    public void it_throws_exception_when_host_does_not_exist()
    {
      var client = new TeamCityClient("test:81");
      client.Connect("admin", "qwerty");

      Assert.Throws<WebException>(() => client.Projects.All());
    }


    [Test]
    public void it_throws_exception_when_no_connection_formed()
    {
      var client = new TeamCityClient(m_server, m_useSsl);

      Assert.Throws<ArgumentException>(() => client.Projects.All());

      //Assert: Exception
    }

    [Test]
    public void it_returns_all_projects()
    {
      List<Project> projects = m_client.Projects.All();

      Assert.That(projects.Any(), "No projects were found for this server");
    }

    [Test]
    public void it_returns_project_details_when_passing_a_project_id()
    {
      string projectId = m_goodProjectId;
      Project projectDetails = m_client.Projects.ById(projectId);

      Assert.That(projectDetails != null, "No details found for that specific project");
    }

    [Test]
    public void it_returns_project_details_when_passing_a_project_name()
    {
      string projectName = m_goodProjectId;
      Project projectDetails = m_client.Projects.ByName(projectName);

      Assert.That(projectDetails != null, "No details found for that specific project");
    }

    [Test]
    public void it_returns_project_details_when_passing_project()
    {
      var project = new Project {Id = m_goodProjectId };
      Project projectDetails = m_client.Projects.Details(project);

      Assert.That(!string.IsNullOrWhiteSpace(projectDetails.Id));
    }


    [Test]
    [Ignore("Modify guid...")]
    public void it_returns_project_details_when_creating_project()
    {
      var client = new TeamCityClient("localhost:81");
      client.Connect("admin", "qwerty");
      var projectName = Guid.NewGuid().ToString("N");
      var project = client.Projects.Create(projectName);

      Assert.That(project, Is.Not.Null);
      Assert.That(project.Name, Is.EqualTo(projectName));
    }
  }
}