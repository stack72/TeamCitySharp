using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.SampleBuildRadiator.Controllers
{
    public class DashboardController : Controller
    {
        private readonly TeamCityClient _client;

        public DashboardController()
        {
            _client = new TeamCityClient("");
            _client.Connect("", "");
        }

        public ActionResult Index()
        {
            var projects = _client.AllProjects();
            var overviewStatus = new List<BuildOverView>();

            foreach (var project in projects)
            {
                var buildTypes = _client.BuildConfigsByProjectId(project.Id);
                foreach (var buildType in buildTypes)
                {
                    var projectOverView = CreateBuildOverview(project, buildType);

                    overviewStatus.Add(projectOverView);
                }
            }

            return View(overviewStatus);
        }

        private BuildOverView CreateBuildOverview(Project project, BuildConfig buildType)
        {
            var lastBuild = _client.LastBuildByBuildConfigId(buildType.Id);
            var buildOverView = new BuildOverView();
            buildOverView.Name = project.Name;
            buildOverView.BuildName = buildType.Name;
            //buildOverView.LastBuildDate = DateTime.Parse(lastBuild.StartDate);
            buildOverView.LastStatus = lastBuild.Status;

            return buildOverView;
        }
    }

    public class BuildOverView  
    {
        public string Name { get; set; }
        public string BuildName { get; set; }
        public DateTime LastBuildDate { get; set; }
        public string LastStatus { get; set; }
    }
}
