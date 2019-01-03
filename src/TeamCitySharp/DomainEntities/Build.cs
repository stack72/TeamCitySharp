using System;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Build
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("buildTypeId")]
    public string BuildTypeId { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("webUrl")]
    public string WebUrl { get; set; }

    [JsonProperty("running")]
    public bool Running { get; set; }

    [JsonProperty("personal")]
    public bool Personal { get; set; }
    
    [JsonProperty("statusText")]
    public string StatusText { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("startDate")]
    public DateTime StartDate { get; set; }

    [JsonProperty("finishDate")]
    public DateTime FinishDate { get; set; }

    [JsonProperty("queuedDate")]
    public DateTime QueuedDate { get; set; }

    [JsonProperty("buildType")]
    public BuildConfig BuildType { get; set; }

    [JsonProperty("buildConfig")]
    public BuildConfig BuildConfig { get; set; }

    [JsonProperty("agent")]
    public Agent Agent { get; set; }

    [JsonProperty("tags")]
    public Tags Tags { get; set; }

    [JsonProperty("changes")]
    public ChangeWrapper Changes { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }

    [JsonProperty("running-info")]
    public Running_info Running_info { get; set; }

    [JsonProperty("snapshot-dependencies")]
    public BuildSnapshotDepencies SnapshotDependencies { get; set; }

    [JsonProperty("artifact-dependencies")]
    public BuildArtifactDependencies ArtifactDependencies { get; set; }

    [JsonProperty("lastChanges")]
    public ChangeWrapper LastChanges { get; set; }

    [JsonProperty("triggered")]
    public Triggered Triggered { get; set; }

    [JsonProperty("revisions")]
    public Revisions Revisions { get; set; }


    public override string ToString()
    {
      return Number;
    }
  }
}