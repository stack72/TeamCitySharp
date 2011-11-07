using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamCitySharp.SampleBuildRadiator.Controllers
{
    public class AgentsController : Controller
    {
        private TeamCityClient _client;
        public ActionResult Index()
        {
            _client = new TeamCityClient("localhost:81");
            _client.Connect("admin", "qwerty");
            var agents = _client.AllAgents();

            return View(agents);
        }

    }
}
