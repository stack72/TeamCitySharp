using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    internal class Branches : IBranches
    {
        private readonly TeamCityCaller _caller;

        internal Branches(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<Branch> ByBuildLocator(BuildTypeLocator locator)
        {
            var branchesWrapper = _caller.GetFormat<BranchesWrapper>("/app/rest/buildTypes/{0}/branches", locator);
            return branchesWrapper.Branch;
        }
    }
}
