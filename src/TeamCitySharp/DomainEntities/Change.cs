using System;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Change
  {
    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("webLink")]
    public string WebLink { get; set; }

    [JsonProperty("webUrl")]
    public string WebUrl { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("personal")]
    public bool Personal { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("comment")]
    public string Comment { get; set; }

    [JsonProperty("files")]
    public FileWrapper Files { get; set; }

    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("vcs-root-instance")]
    public VcsRoot VcsRootInstance { get; set; }
  }
}