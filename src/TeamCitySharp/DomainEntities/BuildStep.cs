using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class BuildStep
  {
    public override string ToString()
    {
      return "step";
    }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("disabled")]
    public string Disabled { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }
  }
}