using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Plugin
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    public override string ToString()
    {
      return DisplayName;
    }
  }
}