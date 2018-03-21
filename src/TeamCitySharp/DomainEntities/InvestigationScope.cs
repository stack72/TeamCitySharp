namespace TeamCitySharp.DomainEntities
{
  public class InvestigationScope
  {
    [JsonFx.Json.JsonName("buildTypes")]
    public BuildTypeWrapper BuildTypes { get; set; }

    [JsonFx.Json.JsonName("project")]
    public Project Project { get; set; }
  }
}