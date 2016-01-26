using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class AgentRequirements
  {
    public override string ToString()
    {
      return "agent-requirements";
    }

    public List<AgentRequirement> AgentRequirement { get; set; }
  }
}