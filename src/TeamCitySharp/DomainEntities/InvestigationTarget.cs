using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class InvestigationTarget
  {
    [JsonProperty("tests")]
    public Tests Tests { get; set; }

    [JsonProperty("anyProblem")]
    public string AnyProblem { get; set; }

    [JsonProperty("resolution")]
    public InvestigationResolution Resolution { get; set; }
  }
}