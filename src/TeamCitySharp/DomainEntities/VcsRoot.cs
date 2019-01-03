using System;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class VcsRoot
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("vcs-root-id")]
    public string VcsRootId { get; set; }

    [JsonProperty("vcsName")]
    public string VcsName { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("lastChecked")]
    public DateTime LastChecked { get; set; }

    [JsonProperty("lastVersion")]
    public string LastVersion { get; set; }

    [JsonProperty("project")]
    public Project Project { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }

    public override string ToString()
    {
      return Name;
    }

   
  }
}