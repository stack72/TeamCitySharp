using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class BuildTypeWrapper
  {
    [JsonFx.Json.JsonName("buildType")]
    public List<BuildConfig> BuildType { get; set; }
  }
}