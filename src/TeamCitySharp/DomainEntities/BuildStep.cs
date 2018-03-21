namespace TeamCitySharp.DomainEntities
{
  public class BuildStep
  {
    public override string ToString()
    {
      return "step";
    }

    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }

    [JsonFx.Json.JsonName("type")]
    public string Type { get; set; }

    [JsonFx.Json.JsonName("disabled")]
    public string Disabled { get; set; }

    [JsonFx.Json.JsonName("properties")]
    public Properties Properties { get; set; }
  }
}