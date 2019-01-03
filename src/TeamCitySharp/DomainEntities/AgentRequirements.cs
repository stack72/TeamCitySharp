using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class AgentRequirements
  {
    public override string ToString()
    {
      return "agent-requirements";
    }

    [JsonProperty("agent-requirement")]
    public List<AgentRequirement> AgentRequirement { get; set; }
  }
}