using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Problem
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("identity")]
    public string Identity { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("mutes")]
    public Mutes Mutes { get; set; }

    [JsonProperty("investigations")]
    public InvestigationWrapper Investigations { get; set; }

    [JsonProperty("problemOccurrences")]
    public ProblemOccurrences ProblemOccurrences { get; set; }

  }
}