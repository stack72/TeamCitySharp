using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class ProblemTarget
  {
    [JsonProperty("anyProblem")]
    public bool AnyProblem { get; set; }

    [JsonProperty("tests")]
    public Tests Tests { get; set; }

    [JsonProperty("problems")]
    public Problems Problems { get; set; }

  }
}