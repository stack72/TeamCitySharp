namespace TeamCitySharp.DomainEntities
{
    public class ArtifactDependency
    {
        public ArtifactDependency()
        {
            Properties = new Properties();
        }
        public override string ToString()
        {
            return Type;
        }

        public string Id { get; set; }
        public Properties Properties { get; set; }
        public Source_BuildType Source_BuildType { get; set; }
        public string Type
        {
            get { return "artifact_dependency"; }
        }

        public static ArtifactDependency Default(string dependsOnbuildId)
        {
            var dependency = new ArtifactDependency();

            dependency.Properties.Add("cleanDestinationDirectory", "true");
            dependency.Properties.Add("pathRules", "* => Temp");
            dependency.Properties.Add("revisionName", "sameChainOrLastFinished");
            dependency.Properties.Add("revisionValue", "latest.sameChainOrLastFinished");

            dependency.Source_BuildType = new Source_BuildType
            {
                Id = dependsOnbuildId
            };

            return dependency;
        }
    }
}