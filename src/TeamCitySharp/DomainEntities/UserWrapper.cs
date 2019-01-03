using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class UserWrapper
  {
    [JsonProperty("user")]
    public List<User> User { get; set; }
  }
}