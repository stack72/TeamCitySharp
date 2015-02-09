using JsonFx.Json;

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
            return Type;
        }

        public string Id { get; set; }
        public Properties Properties { get; set; }
        [JsonName("source-buildType")]
        public SourceBuildType SourceBuildType { get; set; }
        public string Type { get; set; }
        
        public static ArtifactDependency Default(string dependsOnbuildId)
        {
            var dependency = new ArtifactDependency();

            dependency.Properties.Add("cleanDestinationDirectory", "true");
            dependency.Properties.Add("pathRules", "* => Temp");
            dependency.Properties.Add("revisionName", "sameChainOrLastFinished");
            dependency.Properties.Add("revisionValue", "latest.sameChainOrLastFinished");

            dependency.SourceBuildType = new SourceBuildType
            {
                Id = dependsOnbuildId
            };

            return dependency;
        }
    }
}