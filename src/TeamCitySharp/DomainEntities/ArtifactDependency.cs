using System.Runtime.Serialization;

namespace TeamCitySharp.DomainEntities
{
  [DataContract]
  public class ArtifactDependency
  {
    public ArtifactDependency()
    {
      Properties = new Properties();
      Type = "artifact_dependency";
    }

    public override string ToString()
    {
      return "artifact_dependency";
    }

    [DataMember(Name = "id")]
    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [DataMember(Name = "type")]
    [JsonFx.Json.JsonName("type")]
    public string Type { get; set; }

    [DataMember]
    [JsonFx.Json.JsonName("properties")]
    public Properties Properties { get; set; }

    [DataMember(Name = "source-buildType")]
    [JsonFx.Json.JsonName("source-buildType")]
    public BuildConfig SourceBuildType { get; set; }

    public static ArtifactDependency Default(string dependsOnbuildId)
    {
      var dependency = new ArtifactDependency();

      dependency.Properties.Add("cleanDestinationDirectory", "true");
      dependency.Properties.Add("pathRules", "* => Temp");
      dependency.Properties.Add("revisionName", "sameChainOrLastFinished");
      dependency.Properties.Add("revisionValue", "latest.sameChainOrLastFinished");

      dependency.SourceBuildType = new BuildConfig
        {
          Id = dependsOnbuildId
        };

      return dependency;
    }
  }
}