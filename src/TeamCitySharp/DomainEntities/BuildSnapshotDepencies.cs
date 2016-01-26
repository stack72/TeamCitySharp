using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class BuildSnapshotDepencies
  {
    public override string ToString()
    {
      return "snapshot-dependencies";
    }

    public List<Build> Build { get; set; }
  }
}