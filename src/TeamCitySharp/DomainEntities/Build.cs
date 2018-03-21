using System;

namespace TeamCitySharp.DomainEntities
{
  public class Build
  {
    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("number")]
    public string Number { get; set; }

    [JsonFx.Json.JsonName("status")]
    public string Status { get; set; }

    [JsonFx.Json.JsonName("buildTypeId")]
    public string BuildTypeId { get; set; }

    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [JsonFx.Json.JsonName("webUrl")]
    public string WebUrl { get; set; }

    [JsonFx.Json.JsonName("running")]
    public bool Running { get; set; }

    [JsonFx.Json.JsonName("personal")]
    public bool Personal { get; set; }
    
    [JsonFx.Json.JsonName("statusText")]
    public string StatusText { get; set; }

    [JsonFx.Json.JsonName("state")]
    public string State { get; set; }

    [JsonFx.Json.JsonName("startDate")]
    public DateTime StartDate { get; set; }

    [JsonFx.Json.JsonName("finishDate")]
    public DateTime FinishDate { get; set; }

    [JsonFx.Json.JsonName("queuedDate")]
    public DateTime QueuedDate { get; set; }

    [JsonFx.Json.JsonName("buildType")]
    public BuildConfig BuildType { get; set; }

    [JsonFx.Json.JsonName("buildConfig")]
    public BuildConfig BuildConfig { get; set; }

    [JsonFx.Json.JsonName("agent")]
    public Agent Agent { get; set; }

    [JsonFx.Json.JsonName("tags")]
    public Tags Tags { get; set; }

    [JsonFx.Json.JsonName("changes")]
    public ChangeWrapper Changes { get; set; }

    [JsonFx.Json.JsonName("properties")]
    public Properties Properties { get; set; }

    [JsonFx.Json.JsonName("running-info")]
    public Running_info Running_info { get; set; }

    [JsonFx.Json.JsonName("snapshot-dependencies")]
    public BuildSnapshotDepencies SnapshotDependencies { get; set; }

    [JsonFx.Json.JsonName("artifact-dependencies")]
    public BuildArtifactDependencies ArtifactDependencies { get; set; }

    [JsonFx.Json.JsonName("lastChanges")]
    public ChangeWrapper LastChanges { get; set; }

    [JsonFx.Json.JsonName("triggered")]
    public Triggered Triggered { get; set; }

    [JsonFx.Json.JsonName("revisions")]
    public Revisions Revisions { get; set; }


    public override string ToString()
    {
      return Number;
    }
  }
}