namespace TeamCitySharp.DomainEntities
{
  public class ProjectFeature
  {
    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("type")]
    public string Type { get; set; }

    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [JsonFx.Json.JsonName("properties")]
    public Properties Properties { get; set; }
  }
}