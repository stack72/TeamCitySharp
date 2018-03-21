using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class SnapshotDependencies
  {
    public override string ToString()
    {
      return "snapshot-dependencies";
    }
    [JsonFx.Json.JsonName("snapshot-dependency")]
    public List<SnapshotDependency> SnapshotDependency { get; set; }
  }
}