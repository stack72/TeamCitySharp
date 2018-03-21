using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class Templates
  {
    [JsonFx.Json.JsonName("buildType")]
    public List<Template> BuildType { get; set; }
  }
}