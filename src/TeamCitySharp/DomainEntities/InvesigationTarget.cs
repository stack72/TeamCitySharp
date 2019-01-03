using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class InvesigationTarget
  {
    [JsonProperty("tests")]
    public Tests Tests { get; set; }

    [JsonProperty("anyProblem")]
    public string AnyProblem { get; set; }

    [JsonProperty("resolution")]
    public InvesigationResolution Resolution { get; set; }
  }
}