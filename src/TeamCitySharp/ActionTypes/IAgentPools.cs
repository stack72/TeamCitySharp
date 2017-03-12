using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IAgentPools
    {
        List<AgentPool> All();

        List<Agent> AgentsByAgentPoolId(string id);

        List<Project> ProjectsByAgentPoolId(string id);
    }
}