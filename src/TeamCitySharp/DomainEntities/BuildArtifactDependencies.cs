using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class BuildArtifactDependencies
  {
    public override string ToString()
    {
      return "artifact-dependencies";
    }
    [JsonFx.Json.JsonName("build")]
    public List<Build> Build { get; set; }
  }
}