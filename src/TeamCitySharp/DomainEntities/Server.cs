using System;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Server
  {
    [JsonProperty("versionMajor")]
    public string VersionMajor { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("buildNumber")]
    public string BuildNumber { get; set; }

    [JsonProperty("currentTime")]
    public DateTime CurrentTime { get; set; }

    [JsonProperty("startTime")]
    public DateTime StartTime { get; set; }
  }
}