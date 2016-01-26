using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public class Agents : IAgents
  {
    private readonly ITeamCityCaller _caller;
    private string _fields;

    internal Agents(ITeamCityCaller caller)
    {
      _caller = caller;
    }

    public Agents GetFields(string fields)
    {
      var newInstance = (Agents) MemberwiseClone();
      newInstance._fields = fields;
      return newInstance;
    }

    public List<Agent> All(bool includeDisconnected = true, bool includeUnauthorized = true)
    {
      var url =
        string.Format(
          ActionHelper.CreateFieldUrl("/app/rest/agents?includeDisconnected={0}&includeUnauthorized={1}", _fields),
          includeDisconnected.ToString().ToLower(), includeUnauthorized.ToString().ToLower());

      var agentWrapper = _caller.Get<AgentWrapper>(url);

      return agentWrapper.Agent;
    }
  }
}