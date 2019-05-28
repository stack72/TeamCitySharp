using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Mutes
  {
    [JsonProperty("mutes")]
    public List<Mute> Mute { get; set; }
  }
}