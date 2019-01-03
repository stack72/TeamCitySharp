using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class AgentRequirement
  {
    public override string ToString()
    {
      return "agent_requirement";
    }

    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("properties")]
    public Properties Properties { get; set; }
  }
}