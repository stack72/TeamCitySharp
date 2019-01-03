using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class ArtifactDependencies
  {
    public override string ToString()
    {
      return "artifact-dependencies";
    }

    [JsonProperty("artifact-dependency")]
    public List<ArtifactDependency> ArtifactDependency { get; set; }
  }
}