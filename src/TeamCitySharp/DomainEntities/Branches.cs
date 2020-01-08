using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Branches
  {
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("branch")]
    public List<Branch> Branch { get; set; }
  }
}