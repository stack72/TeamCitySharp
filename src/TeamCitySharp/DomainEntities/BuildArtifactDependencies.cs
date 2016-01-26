using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class BuildArtifactDependencies
  {
    public override string ToString()
    {
      return "artifact-dependencies";
    }

    public List<Build> Build { get; set; }
  }
}