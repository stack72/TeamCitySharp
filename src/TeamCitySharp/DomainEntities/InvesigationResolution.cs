namespace TeamCitySharp.DomainEntities
{
  public class InvesigationResolution
  {
    [JsonFx.Json.JsonName("type")]
    public string Type { get; set; }
  }

  public class Resolution
  {
    public const string WhenFixed = "whenFixed";
    public const string Manually = "manually";
  }
}