using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public class Statistics : IStatistics
    {
        private readonly TeamCityCaller _caller;

        internal Statistics(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<Property> GetByBuildId(string buildId)
        {
            return _caller.GetFormat<Properties>("/app/rest/builds/id:{0}/statistics", buildId).Property;
        }
    }
}
