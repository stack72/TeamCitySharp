namespace TeamCitySharp.DomainEntities
{
  public class BuildConfig
  {
    public override string ToString()
    {
      return Name;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public string Status { get; set; }
    public string Href { get; set; }
    public string ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public string WebUrl { get; set; }
    public bool? Personal { get; set; }
    public bool? History { get; set; }
    public bool? Pinned { get; set; }
    public bool? Running { get; set; }

    public Project Project { get; set; }
    public Template Template { get; set; }
    public Parameters Parameters { get; set; }
    public ArtifactDependencies ArtifactDependencies { get; set; }
    public SnapshotDependencies SnapshotDependencies { get; set; }
    public VcsRootEntries VcsRootEntries { get; set; }
    public BuildSteps Steps { get; set; }
    public AgentRequirements AgentRequirements { get; set; }
    public BuildTriggers Triggers { get; set; }
    public Properties Settings { get; set; }
  }
}