namespace TeamCitySharp.DomainEntities
{
  public class Plugin
  {
    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }

    [JsonFx.Json.JsonName("displayName")]
    public string DisplayName { get; set; }

    [JsonFx.Json.JsonName("version")]
    public string Version { get; set; }

    public override string ToString()
    {
      return DisplayName;
    }
  }
}