using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamCitySharp.SampleBuildRadiator.Controllers
{
    public class BuildTypesController : Controller
    {
        private TeamCityClient _client;
        public BuildTypesController()
        {
            _client = new TeamCityClient("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        public ActionResult BuuildTypesBy(string projectId)
        {
            var buildTypes = _client.BuildConfigsByProjectId(projectId);
            return View(buildTypes);
        }
    }
}
