using System;

namespace TeamCitySharp.DomainEntities
{
  public class Triggered
  {
    [JsonFx.Json.JsonName("type")]
    public string Type { get; set; }

    [JsonFx.Json.JsonName("date")]
    public DateTime Date { get; set; }

    [JsonFx.Json.JsonName("buildType")]
    public BuildConfig BuildType { get; set; }

    [JsonFx.Json.JsonName("details")]
    public string Details { get; set;  }

    [JsonFx.Json.JsonName("user")]
    public User User { get; set; }
  }
}
