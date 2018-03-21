using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class UserWrapper
  {
    [JsonFx.Json.JsonName("user")]
    public List<User> User { get; set; }
  }
}