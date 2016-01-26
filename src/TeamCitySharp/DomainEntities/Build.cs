using System;

namespace TeamCitySharp.DomainEntities
{
  public class Build
  {
    public string Id { get; set; }
    public string Number { get; set; }
    public string Status { get; set; }
    public string BuildTypeId { get; set; }
    public string Href { get; set; }
    public string WebUrl { get; set; }
    public bool Running { get; set; }
    public bool Personal { get; set; }
    public string StatusText { get; set; }
    public string State { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    public BuildConfig BuildType { get; set; }
    public BuildConfig BuildConfig { get; set; }
    public Agent Agent { get; set; }
    public ChangeWrapper Changes { get; set; }
    public Properties Properties { get; set; }
    public Running_info Running_info { get; set; }
    public BuildSnapshotDepencies SnapshotDependencies { get; set; }
    public BuildArtifactDependencies ArtifactDependencies { get; set; }

    public override string ToString()
    {
      return Number;
    }
  }
}