using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class ProjectFeatures
  {
    [JsonProperty("projectFeature")]
    public List<ProjectFeature> ProjectFeature { get; set; }
  }
}