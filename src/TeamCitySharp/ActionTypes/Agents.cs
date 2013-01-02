using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class Agents : IAgents
    {
        private readonly TeamCityCaller _caller;

        internal Agents(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<Agent> AllAgents()
        {
            var agentWrapper = _caller.Get<AgentWrapper>("/app/rest/agents");

            return agentWrapper.Agent;
        }

    }
}