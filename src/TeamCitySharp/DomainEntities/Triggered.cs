using System;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Triggered
  {
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("displayText")]
    public string DisplayText { get; set; }

    [JsonProperty("rawValue")]
    public string RawValue { get; set; }

    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("build")]
    public Build Build { get; set; }

    [JsonProperty("buildType")]
    public BuildConfig BuildType { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }
  }
}
