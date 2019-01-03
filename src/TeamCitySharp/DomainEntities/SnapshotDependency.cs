using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
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

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("inherited")]
    public bool Inherited { get; set; }

    [JsonProperty("source-buildType")]
    public BuildConfig SourceBuildType { get; set; }

    public static SnapshotDependency Default(string dependsOnBuildId)
    {
      var dependency = new SnapshotDependency();

      dependency.Properties.Add("run-build-if-dependency-failed", "false");
      dependency.Properties.Add("run-build-on-the-same-agent", "false");
      dependency.Properties.Add("take-started-build-with-same-revisions", "true");
      dependency.Properties.Add("take-successful-builds-only", "true");

      dependency.SourceBuildType = new BuildConfig
        {
          Id = dependsOnBuildId
        };

      return dependency;
    }
  }
}