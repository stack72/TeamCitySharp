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
    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [DataMember]
    [JsonFx.Json.JsonName("properties")]
    public Properties Properties { get; set; }

    [DataMember(Name = "type")]
    [JsonFx.Json.JsonName("type")]
    public string Type { get; set; }

    [DataMember(Name = "inherited")]
    [JsonFx.Json.JsonName("inherited")]
    public bool Inherited { get; set; }

    [DataMember(Name = "source-buildType")]
    [JsonFx.Json.JsonName("source-buildType")]
    public BuildConfig SourceBuildType { get; set; }

    public static SnapshotDependency Default(string dependsOnbuildId)
    {
      var dependency = new SnapshotDependency();

      dependency.Properties.Add("run-build-if-dependency-failed", "false");
      dependency.Properties.Add("run-build-on-the-same-agent", "false");
      dependency.Properties.Add("take-started-build-with-same-revisions", "true");
      dependency.Properties.Add("take-successful-builds-only", "true");

      dependency.SourceBuildType = new BuildConfig
        {
          Id = dependsOnbuildId
        };

      return dependency;
    }
  }
}