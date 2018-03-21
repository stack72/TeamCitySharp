using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class Revisions
  {
    [JsonFx.Json.JsonName("count")]
    public int Count { get; set; }
    [JsonFx.Json.JsonName("revision")]
    public List<Revision> Revision { get; set; }
  }
}
