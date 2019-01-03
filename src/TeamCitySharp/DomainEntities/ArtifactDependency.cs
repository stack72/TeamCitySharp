using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
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

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("inherited")]
    public bool Inherited { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }

    [JsonProperty("source-buildType")]
    public BuildConfig SourceBuildType { get; set; }

    public static ArtifactDependency Default(string dependsOnBuildId)
    {
      var dependency = new ArtifactDependency();

      dependency.Properties.Add("cleanDestinationDirectory", "true");
      dependency.Properties.Add("pathRules", "* => Temp");
      dependency.Properties.Add("revisionName", "sameChainOrLastFinished");
      dependency.Properties.Add("revisionValue", "latest.sameChainOrLastFinished");

      dependency.SourceBuildType = new BuildConfig
        {
          Id = dependsOnBuildId
      };

      return dependency;
    }
  }
}