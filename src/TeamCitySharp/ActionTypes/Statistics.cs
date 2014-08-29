using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public class Statistics : IStatistics
    {
        private readonly ITeamCityCaller caller;

        internal Statistics(ITeamCityCaller caller)
        {
            this.caller = caller;
        }

        public List<Property> GetByBuildId(string buildId)
        {
            return this.caller.GetFormat<Properties>("/app/rest/builds/id:{0}/statistics", buildId).Property;
        }
    }
}