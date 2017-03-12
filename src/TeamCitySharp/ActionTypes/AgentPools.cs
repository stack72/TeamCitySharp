using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class AgentPools : IAgentPools
    {
        private readonly TeamCityCaller _caller;

        internal AgentPools(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<AgentPool> All()
        {
            var agentPoolWrapper = _caller.Get<AgentPoolWrapper>("/app/rest/agentPools");

            return agentPoolWrapper.AgentPool;
        }

        public List<Agent> AgentsByAgentPoolId(string id)
        {
            var agentWrapper = _caller.GetFormat<AgentWrapper>("/app/rest/agentPools/id:{0}/agents", id);

            return agentWrapper?.Agent;
        }

        public List<Project> ProjectsByAgentPoolId(string id)
        {
            var projectWrapper = _caller.GetFormat<ProjectWrapper>("/app/rest/agentPools/id:{0}/projects", id);
            return projectWrapper?.Project;
        }
    }
}