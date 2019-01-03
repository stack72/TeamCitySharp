using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class BuildWrapper
  {
    [JsonProperty("count")]
    public string Count { get; set; }

    [JsonProperty("build")]
    public List<Build> Build { get; set; }
  }
}