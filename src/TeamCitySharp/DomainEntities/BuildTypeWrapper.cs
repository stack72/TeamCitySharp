using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class BuildTypeWrapper
  {
    [JsonProperty("buildType")]
    public List<BuildConfig> BuildType { get; set; }
  }
}