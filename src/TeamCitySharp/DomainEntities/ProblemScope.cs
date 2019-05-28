using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class ProblemScope
  {
    [JsonProperty("project")]
    public Project Project { get; set; }

    [JsonProperty("buildTypes")]
    public List<BuildTypeWrapper> BuildTypes { get; set; }

    [JsonProperty("buildType")]
    public BuildConfig BuildType { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

  }
}