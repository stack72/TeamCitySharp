using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class ProblemOccurrence
  {
    public override string ToString()
    {
      return "problemOccurrence";
    }
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("identity")]
    public string Identity { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("muted")]
    public bool Muted { get; set; }

    [JsonProperty("currentlyInvestigated")]
    public bool CurrentlyInvestigated { get; set; }

    [JsonProperty("currentlyMuted")]
    public bool CurrentlyMuted { get; set; }

    [JsonProperty("logAnchor")]
    public string LogAnchor { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }

    [JsonProperty("additionalData")]
    public string AditionalData { get; set; }

    [JsonProperty("problem")]
    public Problem Problem{ get; set; }

    [JsonProperty("mute")]
    public Mute Mute { get; set; }

    [JsonProperty("build")]
    public Build Build { get; set; }

  }
}
