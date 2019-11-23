using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public interface ITests
    {
        TestOccurrences ByBuildLocator(BuildLocator locator);
        TestOccurrences ByProjectLocator(ProjectLocator locator);
        TestOccurrences ByTestLocator(TestLocator locator);
        List<TestOccurrences> All(BuildLocator locator);
        List<TestOccurrences> All(ProjectLocator locator);
        List<TestOccurrences> All(TestLocator locator);
    }
}
