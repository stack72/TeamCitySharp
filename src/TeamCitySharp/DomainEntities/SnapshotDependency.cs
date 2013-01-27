namespace TeamCitySharp.DomainEntities
{
	public class SnapshotDependency
	{
		public override string ToString()
		{
			return "snapshot_dependency";
		}

		public string Id { get; set; }
		public Properties Properties { get; set; }
	}
}