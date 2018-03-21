using System;

namespace TeamCitySharp.DomainEntities
{
  public class Server
  {
    [JsonFx.Json.JsonName("versonMajor")]
    public string VersonMajor { get; set; }

    [JsonFx.Json.JsonName("version")]
    public string Version { get; set; }

    [JsonFx.Json.JsonName("buildNumber")]
    public string BuildNumber { get; set; }

    [JsonFx.Json.JsonName("currentTime")]
    public DateTime CurrentTime { get; set; }

    [JsonFx.Json.JsonName("startTime")]
    public DateTime StartTime { get; set; }
  }
}