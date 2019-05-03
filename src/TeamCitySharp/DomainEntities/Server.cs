using System;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Server
  {
    [JsonProperty("versionMajor")]
    public string VersionMajor { get; set; }

    [JsonProperty("versionMinor")]
    public string VersionMinor { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("buildNumber")]
    public string BuildNumber { get; set; }

    [JsonProperty("currentTime")]
    public DateTime CurrentTime { get; set; }

    [JsonProperty("startTime")]
    public DateTime StartTime { get; set; }

    [JsonProperty("buildDate")]
    public string BuildDate { get; set; }

    [JsonProperty("internalId")]
    public string InternalId { get; set; }

    [JsonProperty("webUrl")]
    public string WebUrl { get; set; }
  }
}