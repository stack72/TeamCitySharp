using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class ProjectFeature
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }
  }
}