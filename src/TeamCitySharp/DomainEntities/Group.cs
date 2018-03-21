namespace TeamCitySharp.DomainEntities
{
  public class Group
  {
    public override string ToString()
    {
      return Name;
    }
    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }

    [JsonFx.Json.JsonName("key")]
    public string Key { get; set; }

    [JsonFx.Json.JsonName("users")]
    public UserWrapper Users { get; set; }

    [JsonFx.Json.JsonName("roles")]
    public RoleWrapper Roles { get; set; }
  }
}