using JsonFx.Json;

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

		public string Id { get; set; }
	    public Properties Properties { get; set; }
        [JsonName("source-buildType")]
        public SourceBuildType SourceBuildType { get; set; }
        public string Type { get; set; }

        public static SnapshotDependency Default(string dependsOnbuildId)
        {
            var dependency = new SnapshotDependency();

            dependency.Properties.Add("run-build-if-dependency-failed", "RUN_ADD_PROBLEM");
            dependency.Properties.Add("run-build-if-dependency-failed-to-start", "MAKE_FAILED_TO_START");
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