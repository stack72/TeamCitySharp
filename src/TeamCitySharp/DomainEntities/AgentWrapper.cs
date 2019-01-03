using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class AgentWrapper
  {
    [JsonProperty("agent")]
    public List<Agent> Agent { get; set; }
  }
}