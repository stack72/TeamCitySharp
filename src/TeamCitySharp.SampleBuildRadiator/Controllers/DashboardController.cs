using System.Collections.Generic;
using System.Web.Mvc;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.SampleBuildRadiator.Models;

namespace TeamCitySharp.SampleBuildRadiator.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ITeamCityClient _client;

        public DashboardController()
        {
            _client = new TeamCityClient("teamcity.codebetter.com");
            _client.Connect("teamcitysharpuser", "qwerty");
        }

        public ActionResult Index()
        {
            var projects = _client.AllProjects();
            var overviewStatus = new List<BuildOverViewModel>();

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

        private BuildOverViewModel CreateBuildOverview(Project project, BuildConfig buildType)
        {
            var lastBuild = _client.LastBuildByBuildConfigId(buildType.Id);
            var buildOverView = new BuildOverViewModel();
            buildOverView.ProjectName = project.Name;
            buildOverView.BuildName = buildType.Name;
            //buildOverView.LastBuildDate = DateTime.Parse(lastBuild.StartDate);
            buildOverView.LastStatus = lastBuild.Status;

            return buildOverView;
        }
    }
}
