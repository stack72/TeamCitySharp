namespace TeamCitySharp.DomainEntities
{
    public class ArtifactDependency
    {
        public override string ToString()
        {
            return "artifact_dependency";
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public Properties Properties { get; set; }
    }
}