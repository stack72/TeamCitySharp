using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public class Tests : ITests
  {
    #region Attributes

    private ITeamCityCaller m_caller;

    #endregion

    #region Constructor

    internal Tests(ITeamCityCaller caller)
    {
      m_caller = caller;
    }

    #endregion

    #region Public Methods

    public TestOccurrences ByBuildLocator(BuildLocator locator)
    {
      return m_caller.Get<TestOccurrences>($"/testOccurrences?locator=build:({locator})");
    }

    public TestOccurrences ByProjectLocator(ProjectLocator locator)
    {
      return m_caller.Get<TestOccurrences>($"/testOccurrences?locator=currentlyFailing:true,affectedProject:({locator})");
    }

    public TestOccurrences ByTestLocator(TestLocator locator)
    {
      return m_caller.Get<TestOccurrences>($"/testOccurrences?locator=test:({locator})");
    }

    public List<TestOccurrences> All(BuildLocator locator)
    {
      return AllResults(ByBuildLocator(locator));
    }

    public List<TestOccurrences> All(ProjectLocator locator)
    {
      return AllResults(ByProjectLocator(locator));
    }

    public List<TestOccurrences> All(TestLocator locator)
    {
      return AllResults(ByTestLocator(locator));
    }
    #endregion
    #region Private Method
    private List<TestOccurrences> AllResults(TestOccurrences firstPageResult)
    {
      var result = new List<TestOccurrences>() { firstPageResult };
      while (!(string.IsNullOrEmpty(result.Last().NextHref)))
      {
        var response = m_caller.GetNextHref<TestOccurrences>(result.Last().NextHref);
        result.Add(response);
      }
      return result;
    }
    #endregion
  }
}
