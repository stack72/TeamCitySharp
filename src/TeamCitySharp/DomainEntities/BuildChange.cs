using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class BuildChange
  {
    [JsonProperty("nextBuild")]
    public Build NextBuild { get; set; }

    [JsonProperty("prevBuild")]
    public Build PrevBuild { get; set; }
  }
}