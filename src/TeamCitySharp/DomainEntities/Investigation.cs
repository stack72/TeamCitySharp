using System;
using System.Linq;
using System.Text;

namespace TeamCitySharp.DomainEntities
{
  public class Investigation
  {
    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("state")]
    public string State { get; set; }

    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [JsonFx.Json.JsonName("assignee")]
    public User Assignee { get; set; }

    [JsonFx.Json.JsonName("assignment")]
    public InvestigationAssignment Assignment { get; set; }

    [JsonFx.Json.JsonName("scope")]
    public InvestigationScope Scope { get; set; }

    [JsonFx.Json.JsonName("target")]
    public InvesigationTarget Target { get; set; }
  }
}