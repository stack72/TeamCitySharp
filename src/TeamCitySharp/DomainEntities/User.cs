using System;

namespace TeamCitySharp.DomainEntities
{
  public class User
  {
    [JsonFx.Json.JsonName("username")]
    public string Username { get; set; }

    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }

    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [JsonFx.Json.JsonName("user")]
    public string Email { get; set; }

    [JsonFx.Json.JsonName("realm")]
    public string Realm { get; set; }

    [JsonFx.Json.JsonName("lastLogin")]
    public DateTime LastLogin { get; set; }

    [JsonFx.Json.JsonName("properties")]

    public Properties Properties { get; set; }

    [JsonFx.Json.JsonName("roles")]
    public RoleWrapper Roles { get; set; }

    [JsonFx.Json.JsonName("groups")]
    public UserGroupWrapper Groups { get; set; }



    public override string ToString()
    {
      return Username;
    }
  }
}