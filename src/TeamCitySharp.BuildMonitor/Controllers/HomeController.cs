using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildMonitor.Repository;

namespace BuildMonitor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(); ;
        }


        public JsonResult GetProjects()
        {
            try
            {
                using (BuildMonitorRepository repo = new BuildMonitorRepository(Properties.Settings.Default.TeamCityURL))
                {
                    var results = repo.GetAllProjectSummary();
                    return Json(new { success = true, results = results }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}
