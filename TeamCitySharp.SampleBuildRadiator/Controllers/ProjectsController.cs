using System.Web.Mvc;

namespace TeamCitySharp.SampleBuildRadiator.Controllers
{
    public class ProjectsController : Controller
    {
        private TeamCityClient _client;
        public ActionResult Index()
        {
            _client = new TeamCityClient("localhost:81");
            _client.Connect("admin", "qwerty");
            var projects = _client.AllProjects();

            return View(projects);
        }

    }
}
