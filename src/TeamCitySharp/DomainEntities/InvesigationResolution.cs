using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class InvesigationResolution
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