using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class RoleWrapper
  {
    [JsonProperty("role")]
    public List<Role> Role { get; set; }
  }
}