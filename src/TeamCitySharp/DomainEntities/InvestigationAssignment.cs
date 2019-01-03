using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class InvestigationAssignment
  {
    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("timestamp")]
    public string TimeStamp { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }
  }
}