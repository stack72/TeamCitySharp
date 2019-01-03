using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class ChangeWrapper
  {
    [JsonProperty("change")]
    public List<Change> Change { get; set; }
  }
}