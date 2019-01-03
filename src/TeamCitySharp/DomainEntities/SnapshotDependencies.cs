using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class SnapshotDependencies
  {
    public override string ToString()
    {
      return "snapshot-dependencies";
    }

    [JsonProperty("snapshot-dependency")]
    public List<SnapshotDependency> SnapshotDependency { get; set; }
  }
}