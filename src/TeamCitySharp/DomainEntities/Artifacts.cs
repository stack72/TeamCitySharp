using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class RelatedIssues
  {
    [JsonProperty("href")]
    public string Href { get; set; }
  }
}