using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Statistics
  {
    [JsonProperty("href")]
    public string Href { get; set; }
  }
}