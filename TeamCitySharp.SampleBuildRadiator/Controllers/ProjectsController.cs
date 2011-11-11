using System.Web.Mvc;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.SampleBuildRadiator.Controllers
{
    public class ProjectsController : Controller
    {
        private TeamCityClient _client;

        public ProjectsController()
        {
            _client = new TeamCityClient("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        public ActionResult Index()
        {
             var projects = _client.AllProjects();

            return View(projects);
        }

        public ActionResult ProjectDetails(Project project)
        {
            var projectDetails = _client.ProjectDetails(project);

            return View(projectDetails);
        }
    }
}
