using System.Runtime.Serialization;

namespace TeamCitySharp.DomainEntities
{
    [DataContract]
	public class SnapshotDependency
	{
		public override string ToString()
		{
			return "snapshot_dependency";
		}
        [DataMember(Name = "id")]
		public string Id { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "properties")]
		public Properties Properties { get; set; }
        [DataMember(Name = "source-buildType")]
        public SourceBuildType SourceBuildType { get; set; }
	}
}