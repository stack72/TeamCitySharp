using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    /// <summary>
    /// This class is named BuildI to avoid confusion with the Build domain entity
    /// </summary>
    internal class BuildI : IBuild
    {
        private readonly TeamCityCaller _caller;

        internal BuildI(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public Build ByBuildLocator(Locators.BuildLocator locator)
        {
            return _caller.GetFormat<Build>(string.Format("/app/rest/builds/{0}", locator));
        }
    }
}
