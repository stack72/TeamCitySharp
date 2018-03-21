namespace TeamCitySharp.DomainEntities
{
  public class Role
  {
    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [JsonFx.Json.JsonName("scope")]
    public string Scope { get; set; }

    [JsonFx.Json.JsonName("roleId")]
    public string RoleId { get; set; }

    public override string ToString()
    {
      return RoleId;
    }
  }
}