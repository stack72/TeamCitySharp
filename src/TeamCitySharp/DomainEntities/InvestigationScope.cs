using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class InvestigationScope
  {
    [JsonProperty("buildTypes")]
    public BuildTypeWrapper BuildTypes { get; set; }

    [JsonProperty("project")]
    public Project Project { get; set; }
  }
}