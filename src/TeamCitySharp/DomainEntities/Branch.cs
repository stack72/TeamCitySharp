using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Branch
  {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("active")]
    public bool Active { get; set; }
    [JsonProperty("default")]
    public bool Default { get; set; }
    [JsonProperty("lastActivity")]
    public bool LastActivity { get; set; }
  }
}