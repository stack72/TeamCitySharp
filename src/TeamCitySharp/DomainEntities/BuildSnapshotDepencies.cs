using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class BuildSnapshotDepencies
  {
    public override string ToString()
    {
      return "snapshot-dependencies";
    }
    [JsonProperty("build")]
    public List<Build> Build { get; set; }
  }
}