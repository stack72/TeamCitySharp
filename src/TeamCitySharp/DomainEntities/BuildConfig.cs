namespace TeamCitySharp.DomainEntities
{
  public class BuildConfig
  {
    public override string ToString()
    {
      return Name;
    }

    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }

    [JsonFx.Json.JsonName("number")]
    public string Number { get; set; }

    [JsonFx.Json.JsonName("status")]
    public string Status { get; set; }

    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [JsonFx.Json.JsonName("projectId")]
    public string ProjectId { get; set; }

    [JsonFx.Json.JsonName("projectName")]
    public string ProjectName { get; set; }

    [JsonFx.Json.JsonName("description")]
    public string Description { get; set; }

    [JsonFx.Json.JsonName("webUrl")]
    public string WebUrl { get; set; }

    [JsonFx.Json.JsonName("personal")]
    public bool? Personal { get; set; }

    [JsonFx.Json.JsonName("cancelled")]
    public bool? Cancelled { get; set; }

    [JsonFx.Json.JsonName("history")]
    public bool? History { get; set; }

    [JsonFx.Json.JsonName("pinned")]
    public bool? Pinned { get; set; }

    [JsonFx.Json.JsonName("running")]
    public bool? Running { get; set; }

    [JsonFx.Json.JsonName("project")]
    public Project Project { get; set; }

    [JsonFx.Json.JsonName("template")]
    public Template Template { get; set; }

    [JsonFx.Json.JsonName("parameters")]
    public Parameters Parameters { get; set; }

    [JsonFx.Json.JsonName("artifact-dependencies")]
    public ArtifactDependencies ArtifactDependencies { get; set; }

    [JsonFx.Json.JsonName("snapshot-dependencies")]
    public SnapshotDependencies SnapshotDependencies { get; set; }

    [JsonFx.Json.JsonName("vcs-root-entries")]
    public VcsRootEntries VcsRootEntries { get; set; }

    [JsonFx.Json.JsonName("steps")]
    public BuildSteps Steps { get; set; }

    [JsonFx.Json.JsonName("agent-requirements")]
    public AgentRequirements AgentRequirements { get; set; }

    [JsonFx.Json.JsonName("triggers")]
    public BuildTriggers Triggers { get; set; }

    [JsonFx.Json.JsonName("settings")]
    public Properties Settings { get; set; }
  }
}