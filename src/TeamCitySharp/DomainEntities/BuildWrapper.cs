using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class BuildWrapper
  {
    [JsonFx.Json.JsonName("count")]
    public string Count { get; set; }

    [JsonFx.Json.JsonName("build")]
    public List<Build> Build { get; set; }
  }
}