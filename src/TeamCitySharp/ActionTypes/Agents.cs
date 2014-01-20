using System.Collections.Generic;
using System.IO;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class Agents : IAgents
    {
        private readonly ITeamCityCaller _caller;

        internal Agents(ITeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<Agent> All(bool includeDisconnected = true, bool includeUnauthorized = true)
        {
            var url = string.Format("/app/rest/agents?includeDisconnected={0}&includeUnauthorized={1}",
                includeDisconnected.ToString().ToLower(), includeUnauthorized.ToString().ToLower());

            var agentWrapper = _caller.Get<AgentWrapper>(url);

            return agentWrapper.Agent;
        }

        private string AddqueryString(string url, string queryString)
        {
            if (url.Contains("?"))
                url += "&";
            else
                url += "?";

            url += queryString;

            return url;
        }
    }
}