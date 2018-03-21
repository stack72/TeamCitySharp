using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class RoleWrapper
  {
    [JsonFx.Json.JsonName("role")]
    public List<Role> Role { get; set; }
  }
}