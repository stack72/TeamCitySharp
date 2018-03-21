using System;

namespace TeamCitySharp.DomainEntities
{
  public class Change
  {
    [JsonFx.Json.JsonName("username")]
    public string Username { get; set; }

    [JsonFx.Json.JsonName("webLink")]
    public string WebLink { get; set; }

    [JsonFx.Json.JsonName("webUrl")]
    public string WebUrl { get; set; }

    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("version")]
    public string Version { get; set; }

    [JsonFx.Json.JsonName("personal")]
    public bool Personal { get; set; }

    [JsonFx.Json.JsonName("date")]
    public DateTime Date { get; set; }

    [JsonFx.Json.JsonName("comment")]
    public string Comment { get; set; }

    [JsonFx.Json.JsonName("files")]
    public FileWrapper Files { get; set; }

    [JsonFx.Json.JsonName("user")]
    public User User { get; set; }

    [JsonFx.Json.JsonName("vcs-root-instance")]
    public VcsRoot VcsRootInstance { get; set; }
  }
}