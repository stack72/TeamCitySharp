using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface IBranches
    {
        List<Branch> ByBuildLocator(BuildTypeLocator locator);
    }
}
