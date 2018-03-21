namespace TeamCitySharp.DomainEntities
{
  public class AgentRequirement
  {
    public override string ToString()
    {
      return "agent_requirement";
    }

    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }
    [JsonFx.Json.JsonName("type")]
    public string Type { get; set; }
    [JsonFx.Json.JsonName("properties")]
    public Properties Properties { get; set; }
  }
}