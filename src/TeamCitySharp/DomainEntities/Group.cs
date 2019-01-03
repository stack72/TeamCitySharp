using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Group
  {
    public override string ToString()
    {
      return Name;
    }
    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("key")]
    public string Key { get; set; }

    [JsonProperty("users")]
    public UserWrapper Users { get; set; }

    [JsonProperty("roles")]
    public RoleWrapper Roles { get; set; }
  }
}