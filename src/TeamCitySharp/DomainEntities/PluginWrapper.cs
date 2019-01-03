using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class PluginWrapper
  {
    [JsonProperty("plugin")]
    public List<Plugin> Plugin { get; set; }
  }
}