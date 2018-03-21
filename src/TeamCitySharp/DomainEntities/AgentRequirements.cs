using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class AgentRequirements
  {
    public override string ToString()
    {
      return "agent-requirements";
    }
    [JsonFx.Json.JsonName("agent-requirement")]
    public List<AgentRequirement> AgentRequirement { get; set; }
  }
}