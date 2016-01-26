using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class BuildWrapper
  {
    public string Count { get; set; }
    public List<Build> Build { get; set; }
  }
}