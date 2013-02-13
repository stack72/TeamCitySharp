using System.Linq;
using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    internal class BuildDetails : IBuildDetails
    {
        private readonly TeamCityCaller _caller;

        internal BuildDetails(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public Build ByBuildLocator(BuildLocator locator)
        {
            var buildWrapper = _caller.GetFormat<BuildWrapper>("/app/rest/builds/{0}", locator);

            return buildWrapper.Build == null ? null : buildWrapper.Build.FirstOrDefault();
        }
    }
}