using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamCitySharp.SampleBuildRadiator.Controllers
{
    public class UsersController : Controller
    {
        private TeamCityClient _client;
        public ActionResult Index()
        {
            _client = new TeamCityClient("localhost:81");
            _client.Connect("admin", "qwerty");
            var users = _client.AllUsers();

            return View(users);
        }

    }
}
