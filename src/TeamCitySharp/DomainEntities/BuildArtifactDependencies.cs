using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class BuildArtifactDependencies
  {
    public override string ToString()
    {
      return "artifact-dependencies";
    }
    [JsonProperty("build")]
    public List<Build> Build { get; set; }
  }
}