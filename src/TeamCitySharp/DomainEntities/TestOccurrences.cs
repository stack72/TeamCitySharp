using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class TestOccurrences
  {
    public override string ToString()
    {
      return "testOccurrences";
    }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("nextHref")]
    public string NextHref { get; set; }

    [JsonProperty("prevHref")]
    public string PrevHref { get; set; }

    [JsonProperty("testOccurrence")]
    public List<TestOccurrence> TestOccurrence { get; set; }

    [JsonProperty("default")]
    public bool Default { get; set; }

    [JsonProperty("passed")]
    public int Passed { get; set; }

    [JsonProperty("failed")]
    public int Failed { get; set; }

    [JsonProperty("newFailed")]
    public int NewFailed { get; set; }

    [JsonProperty("ignored")]
    public int Ignored { get; set; }

    [JsonProperty("muted")]
    public int Muted { get; set; }
  }
}
