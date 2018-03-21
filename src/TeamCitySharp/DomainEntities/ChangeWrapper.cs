using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class ChangeWrapper
  {
    [JsonFx.Json.JsonName("change")]
    public List<Change> Change { get; set; }
  }
}