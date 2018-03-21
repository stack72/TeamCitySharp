using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class ArtifactDependencies
  {
    public override string ToString()
    {
      return "artifact-dependencies";
    }

    [JsonFx.Json.JsonName("artifact-dependency")]
    public List<ArtifactDependency> ArtifactDependency { get; set; }
  }
}