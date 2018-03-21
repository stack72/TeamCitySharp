using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class BuildTriggers
  {
    public override string ToString()
    {
      return "triggers";
    }
    [JsonFx.Json.JsonName("trigger")]
    public List<BuildTrigger> Trigger { get; set; }
  }
}