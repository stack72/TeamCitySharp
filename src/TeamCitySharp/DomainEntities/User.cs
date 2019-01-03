using System;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class User
  {
    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("realm")]
    public string Realm { get; set; }

    [JsonProperty("lastLogin")]
    public DateTime LastLogin { get; set; }

    [JsonProperty("properties")]

    public Properties Properties { get; set; }

    [JsonProperty("roles")]
    public RoleWrapper Roles { get; set; }

    [JsonProperty("groups")]
    public UserGroupWrapper Groups { get; set; }



    public override string ToString()
    {
      return Username;
    }
  }
}