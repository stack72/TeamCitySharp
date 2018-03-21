using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class PluginWrapper
  {
    [JsonFx.Json.JsonName("plugin")]
    public List<Plugin> Plugin { get; set; }
  }
}