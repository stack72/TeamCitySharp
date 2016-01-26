using NUnit.Framework;
using System.Linq;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_interacting_to_get_build_statistics
  {
    private ITeamCityClient _client;

    [SetUp]
    public void SetUp()
    {
      _client = new TeamCityClient("teamcity.codebetter.com");
      _client.Connect("teamcitysharpuser", "qwerty");
    }

    [Test]
    public void it_returns_no_of_tests_from_last_successful_build()
    {
      var proj = _client.Projects.ById("AutoFixture");
      var build = _client.Builds.LastSuccessfulBuildByBuildConfigId(proj.BuildTypes.BuildType[0].Id);
      var stats = _client.Statistics.GetByBuildId(build.Id);

      Assert.That(stats.Any(property => property.Name.Equals("PassedTestCount")));
    }
  }
}