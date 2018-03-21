using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class AgentWrapper
  {
    [JsonFx.Json.JsonName("agent")]
    public List<Agent> Agent { get; set; }
  }
}