using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public class Agents : IAgents
  {
    private readonly ITeamCityCaller m_caller;
    private string m_fields;

    internal Agents(ITeamCityCaller caller)
    {
      m_caller = caller;
    }

    public Agents GetFields(string fields)
    {
      var newInstance = (Agents) MemberwiseClone();
      newInstance.m_fields = fields;
      return newInstance;
    }

    public List<Agent> All(bool includeDisconnected = true, bool includeUnauthorized = true)
    {
      var url =
        string.Format(
          ActionHelper.CreateFieldUrl("/app/rest/agents?includeDisconnected={0}&includeUnauthorized={1}", m_fields),
          includeDisconnected.ToString().ToLower(), includeUnauthorized.ToString().ToLower());

      var agentWrapper = m_caller.Get<AgentWrapper>(url);

      return agentWrapper.Agent;
    }
  }
}