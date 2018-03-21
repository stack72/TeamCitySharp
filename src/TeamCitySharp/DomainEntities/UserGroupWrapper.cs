using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class UserGroupWrapper
  {
    [JsonFx.Json.JsonName("group")]
    public List<Group> Group { get; set; }
  }
}