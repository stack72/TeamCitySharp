using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Mute
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("assignment")]
    public Comment Assignment { get; set; }

    [JsonProperty("scope")]
    public ProblemScope Scope { get; set; }

    [JsonProperty("target")]
    public ProblemTarget target { get; set; }

    [JsonProperty("resolution")]
    public Resolution resolution { get; set; }
  }
}