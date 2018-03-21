namespace TeamCitySharp.DomainEntities
{
  public class InvestigationAssignment
  {
    [JsonFx.Json.JsonName("user")]
    public User User { get; set; }

    [JsonFx.Json.JsonName("timestamp")]
    public string TimeStamp { get; set; }

    [JsonFx.Json.JsonName("text")]
    public string Text { get; set; }
  }
}