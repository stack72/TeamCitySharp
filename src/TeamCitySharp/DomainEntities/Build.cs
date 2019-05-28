using System;
using Newtonsoft.Json;
using TeamCitySharp.ActionTypes;

namespace TeamCitySharp.DomainEntities
{
  public class Build
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("taskId")]
    public string TaskId { get; set; }

    [JsonProperty("buildTypeId")]
    public string BuildTypeId { get; set; }

    [JsonProperty("buildTypeInternalId")]
    public string BuildTypeInternalId { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("running")]
    public bool Running { get; set; }

    [JsonProperty("composite")]
    public bool Composite { get; set; }

    [JsonProperty("failedToStart")]
    public bool FailedToStart { get; set; }

    [JsonProperty("personal")]
    public bool Personal { get; set; }

    [JsonProperty("percentageComplete")]
    public string PercentageComplete { get; set; }

    [JsonProperty("branchName")]
    public string BranchName { get; set; }

    [JsonProperty("defaultBranch")]
    public string DefaultBranch { get; set; }

    [JsonProperty("unspecifiedBranch")]
    public string UnspecifiedBranch { get; set; }

    [JsonProperty("history")]
    public string History { get; set; }

    [JsonProperty("pinned")]
    public string Pinned { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("webUrl")]
    public string WebUrl { get; set; }

    [JsonProperty("queuePosition")]
    public string QueuePosition { get; set; }

    [JsonProperty("limitedChangesCount")]
    public string LimitedChangesCount { get; set; }

    [JsonProperty("artifactsDirectory")]
    public string ArtifactsDirectory { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }
    
    [JsonProperty("statusText")]
    public string StatusText { get; set; }

    [JsonProperty("buildType")]
    public BuildConfig BuildType { get; set; }

    [JsonProperty("comment")]
    public Comment Comment { get; set; }

    [JsonProperty("tags")]
    public Tags Tags { get; set; }

    [JsonProperty("pinInfo")]
    public Comment PinInfo { get; set; }

    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("startEstimate")]
    public string StartEstimate { get; set; }

    [JsonProperty("waitReason")]
    public string WaitReason { get; set; }

    [JsonProperty("running-info")]
    public Running_info Running_info { get; set; }

    [JsonProperty("canceledInfo")]
    public Comment CanceledInfo { get; set; }

    [JsonProperty("queuedDate")]
    public DateTime QueuedDate { get; set; }


    [JsonProperty("startDate")]
    public DateTime StartDate { get; set; }

    [JsonProperty("finishDate")]
    public DateTime FinishDate { get; set; }

    [JsonProperty("triggered")]
    public Triggered Triggered { get; set; }

    [JsonProperty("lastChanges")]
    public ChangeWrapper LastChanges { get; set; }

    [JsonProperty("changes")]
    public ChangeWrapper Changes { get; set; }

    [JsonProperty("revisions")]
    public Revisions Revisions { get; set; }

    [JsonProperty("versionedSettingsRevision")]
    public Revision VersionedSettingsRevision { get; set; }

    [JsonProperty("artifactDependencyChanges")]
    public BuildChanges ArtifactDependencyChanges { get; set; }

    [JsonProperty("agent")]
    public Agent Agent { get; set; }

    [JsonProperty("compatibleAgents")]
    public CompatibleAgents CompatibleAgents { get; set; }


    [JsonProperty("testOccurrences")]
    public TestOccurrences TestOccurrences { get; set; }

    [JsonProperty("problemOccurrences")]
    public ProblemOccurrences ProblemOccurrences { get; set; }

    [JsonProperty("artifacts")]
    public Artifacts Artifacts { get; set; }

    [JsonProperty("relatedIssues")]
    public RelatedIssues RelatedIssues { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }


    [JsonProperty("resultingProperties")]
    public Properties ResultingProperties { get; set; }

    [JsonProperty("attributes")]
    public Entries Attributes { get; set; }

    [JsonProperty("statistics")]
    public Statistics Statistics { get; set; }

    [JsonProperty("metadata")]
    public Datas Metadata { get; set; }

    [JsonProperty("snapshot-dependencies")]
    public BuildSnapshotDepencies SnapshotDependencies { get; set; }

    [JsonProperty("artifact-dependencies")]
    public BuildArtifactDependencies ArtifactDependencies { get; set; }

    [JsonProperty("custom-artifact-dependencies")]
    public ArtifactDependencies CustomArtifactDependencies { get; set; }

    [JsonProperty("settingsHash")]
    public string SettingsHash { get; set; }

    [JsonProperty("currentSettingsHash")]
    public string CurrentSettingsHash { get; set; }

    [JsonProperty("modificationId")]
    public string ModificationId { get; set; }

    [JsonProperty("chainModificationId")]
    public string ChainModificationId { get; set; }

    [JsonProperty("usedByOtherBuilds")]
    public bool UsedByOtherBuilds { get; set; }

    [JsonProperty("statusChangeComment")]
    public Comment StatusChangeComment { get; set; }


    // Old Config
    [JsonProperty("buildConfig")]
    public BuildConfig BuildConfig { get; set; }

    public override string ToString()
    {
      return Number;
    }
  }
}