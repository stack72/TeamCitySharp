using JsonFx.Json;
using System.Runtime.Serialization;

namespace TeamCitySharp.DomainEntities
{
  [DataContract]
  public class SnapshotDependency
  {
    public SnapshotDependency()
    {
      Properties = new Properties();
      Type = "snapshot_dependency";
    }

    public override string ToString()
    {
      return Type;
    }

    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "properties")]
    public Properties Properties { get; set; }

    [DataMember(Name = "type")]
    public string Type { get; set; }

    [DataMember(Name = "source-buildType")]
    public SourceBuildType SourceBuildType { get; set; }

    public static SnapshotDependency Default(string dependsOnbuildId)
    {
      var dependency = new SnapshotDependency();

      dependency.Properties.Add("run-build-if-dependency-failed", "false");
      dependency.Properties.Add("run-build-on-the-same-agent", "false");
      dependency.Properties.Add("take-started-build-with-same-revisions", "true");
      dependency.Properties.Add("take-successful-builds-only", "true");

      dependency.SourceBuildType = new SourceBuildType
        {
          Id = dependsOnbuildId
        };

      return dependency;
    }
  }
}