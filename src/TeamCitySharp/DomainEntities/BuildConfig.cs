using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class BuildConfig
  {
    public override string ToString()
    {
      return Name;
    }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("projectId")]
    public string ProjectId { get; set; }

    [JsonProperty("projectName")]
    public string ProjectName { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("webUrl")]
    public string WebUrl { get; set; }

    [JsonProperty("personal")]
    public bool? Personal { get; set; }

    [JsonProperty("cancelled")]
    public bool? Cancelled { get; set; }

    [JsonProperty("history")]
    public bool? History { get; set; }

    [JsonProperty("pinned")]
    public bool? Pinned { get; set; }

    [JsonProperty("running")]
    public bool? Running { get; set; }

    [JsonProperty("project")]
    public Project Project { get; set; }

    [JsonProperty("template")]
    public Template Template { get; set; }

    [JsonProperty("templates")]
    public Templates Templates { get; set; }

    [JsonProperty("parameters")]
    public Parameters Parameters { get; set; }

    [JsonProperty("artifact-dependencies")]
    public ArtifactDependencies ArtifactDependencies { get; set; }

    [JsonProperty("snapshot-dependencies")]
    public SnapshotDependencies SnapshotDependencies { get; set; }

    [JsonProperty("vcs-root-entries")]
    public VcsRootEntries VcsRootEntries { get; set; }

    [JsonProperty("steps")]
    public BuildSteps Steps { get; set; }

    [JsonProperty("agent-requirements")]
    public AgentRequirements AgentRequirements { get; set; }

    [JsonProperty("triggers")]
    public BuildTriggers Triggers { get; set; }

    [JsonProperty("settings")]
    public Properties Settings { get; set; }

    [JsonProperty("builds")]
    public BuildWrapper Builds { get; set; }

    [JsonProperty("investigations")]
    public InvestigationWrapper Investigations { get; set; }

    [JsonProperty("compatibleAgents")]
    public CompatibleAgents CompatibleAgents { get; set; }
  }
}