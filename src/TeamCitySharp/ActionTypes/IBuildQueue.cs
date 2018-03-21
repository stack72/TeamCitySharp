using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public interface IBuildQueue
  {
    List<Build> ByBuildTypeLocator(BuildTypeLocator locator);

    List<Build> ByProjectLocater(ProjectLocator projectLocator);
  }
}