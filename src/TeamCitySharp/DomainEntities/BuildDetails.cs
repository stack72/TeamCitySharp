using System;

namespace TeamCitySharp.DomainEntities
{
    public class BuildDetails
    {
        public int Id { get; set; }
        public string BuildTypeId { get; set; }
        public string State { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }
        public BuildType BuildType { get; set; }
        public string WaitReason { get; set; }
        public DateTime? QueuedDate { get; set; }
        public TriggeredInfo Triggered { get; set; }
        public Change Changes { get; set; }
        public Revisions Revisions { get; set; }
        public CompatibleAgents CompatibleAgents { get; set; }
        public ArtifactsInfo Artifacts { get; set; }
    }
}
