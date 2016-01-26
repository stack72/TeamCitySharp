using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class ArtifactDependencies
  {
    public override string ToString()
    {
      return "artifact-dependencies";
    }

    public List<ArtifactDependency> ArtifactDependency { get; set; }
  }
}