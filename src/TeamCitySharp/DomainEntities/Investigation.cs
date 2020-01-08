using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Investigation
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("assignee")]
    public User Assignee { get; set; }

    [JsonProperty("assignment")]
    public InvestigationAssignment Assignment { get; set; }

    [JsonProperty("scope")]
    public InvestigationScope Scope { get; set; }

    [JsonProperty("target")]
    public InvestigationTarget Target { get; set; }

    [JsonProperty("resolution")]
    public InvestigationResolution Resolution { get; set; }
  }
}