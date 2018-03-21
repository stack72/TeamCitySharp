namespace TeamCitySharp.DomainEntities
{
  public class InvesigationTarget
  {
    [JsonFx.Json.JsonName("tests")]
    public Tests Tests { get; set; }

    [JsonFx.Json.JsonName("anyProblem")]
    public string AnyProblem { get; set; }

    [JsonFx.Json.JsonName("resolution")]
    public InvesigationResolution Resolution { get; set; }
  }
}