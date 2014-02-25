namespace TeamCitySharp.DomainEntities
{
	public class SnapshotDependency
	{
	    public SnapshotDependency()
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
            get { return "snapshot_dependency"; }
        }

        public static SnapshotDependency Default(string dependsOnbuildId)
        {
            var dependency = new SnapshotDependency();

            dependency.Properties.Add("run-build-if-dependency-failed", "false");
            dependency.Properties.Add("run-build-on-the-same-agent", "false");
            dependency.Properties.Add("take-started-build-with-same-revisions", "true");
            dependency.Properties.Add("take-successful-builds-only", "true");

            dependency.Source_BuildType = new Source_BuildType
            {
                Id = dependsOnbuildId
            };

            return dependency;
        }
	}
}