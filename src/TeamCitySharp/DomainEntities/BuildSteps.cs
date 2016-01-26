using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class BuildSteps
  {
    public override string ToString()
    {
      return "steps";
    }

    public List<BuildStep> Step { get; set; }
  }
}