using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class UserGroupWrapper
  {
    [JsonProperty("group")]
    public List<Group> Group { get; set; }
  }
}