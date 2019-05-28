using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class BuildChanges
  {
    public override string ToString()
    {
      return "BuildChanges";
    }

    [JsonProperty("count")]
    public string Count { get; set; }

    [JsonProperty("buildChange")]
    public List<BuildChange> BuildChange { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }
  }
}
