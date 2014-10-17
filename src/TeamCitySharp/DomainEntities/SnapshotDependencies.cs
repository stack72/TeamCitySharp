using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
	public class SnapshotDependencies
	{
		public override string ToString()
		{
			return "snapshot-dependencies";
		}

		public List<SnapshotDependency> SnapshotDependency { get; set; }

        public string GetAsXml()
        {
            if (SnapshotDependency == null)
                return "<snapshot-dependencies/>";
            string result = string.Empty;
            result += "<snapshot-dependencies count=\"" + SnapshotDependency.Count + "\">";
            foreach (var item in SnapshotDependency)
            {
                result += "<snapshot-dependency id=\"" + item.Id + "\">";
                result += item.Properties.GetAsXml();
                result += "</snapshot-dependency>";
            }
            result += "</snapshot-dependencies>";
            return result;
        }
    }
}