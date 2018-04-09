using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class ProjectFeatures
  {
    [JsonFx.Json.JsonName("projectFeature")]
    public List<ProjectFeature> ProjectFeature { get; set; }
  }
}