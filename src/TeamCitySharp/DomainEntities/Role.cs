using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Role
  {
    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("scope")]
    public string Scope { get; set; }

    [JsonProperty("roleId")]
    public string RoleId { get; set; }

    public override string ToString()
    {
      return RoleId;
    }
  }
}