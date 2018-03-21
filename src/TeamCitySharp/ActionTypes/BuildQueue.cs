using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public class BuildQueue : IBuildQueue
  {
    private readonly ITeamCityCaller m_caller;

    internal BuildQueue(ITeamCityCaller caller)
    {
      m_caller = caller;
    }

    public List<Build> ByBuildTypeLocator(BuildTypeLocator locator)
    {
      var buildWrapper = m_caller.Get<BuildWrapper>($"/app/rest/buildQueue?locator=buildType:({locator})");
      return int.Parse(buildWrapper.Count) > 0 ? buildWrapper.Build : new List<Build>();
    }

    public List<Build> ByProjectLocater(ProjectLocator locator)
    {
      var buildWrapper = m_caller.Get<BuildWrapper>($"/app/rest/buildQueue?locator=project:({locator})");
      return int.Parse(buildWrapper.Count) > 0 ? buildWrapper.Build : new List<Build>();
    }
  }
}