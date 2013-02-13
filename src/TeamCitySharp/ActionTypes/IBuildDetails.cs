using System.Linq;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface IBuildDetails
    {
        Build ByBuildLocator(BuildLocator locator);
    }
}