using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Problems
  {
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("nextHref")]
    public string NextHref { get; set; }

    [JsonProperty("prevHref")]
    public string PrevHref { get; set; }

    [JsonProperty("default")]
    public string Default { get; set; }

    [JsonProperty("Problem")]
    public List<Problem> Problem { get; set; }
  }
}