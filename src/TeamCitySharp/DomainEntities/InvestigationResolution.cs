using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class InvestigationResolution
  {
    [JsonProperty("type")]
    public string Type { get; set; }
  }

  public class Resolution
  {
    public const string WhenFixed = "whenFixed";
    public const string Manually = "manually";
  }
}