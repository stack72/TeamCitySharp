using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class BuildSteps
  {
    public override string ToString()
    {
      return "steps";
    }
    [JsonFx.Json.JsonName("step")]
    public List<BuildStep> Step { get; set; }
  }
}