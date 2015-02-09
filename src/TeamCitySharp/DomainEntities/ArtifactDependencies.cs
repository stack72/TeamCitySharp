using System.Collections.Generic;
using System.Web;

namespace TeamCitySharp.DomainEntities
{
    public class ArtifactDependencies
    {
        public override string ToString()
        {
            return "artifact-dependencies";
        }

        public List<ArtifactDependency> ArtifactDependency { get; set; }

        public string GetAsXml()
        {
            if (ArtifactDependency == null)
                return "<artifact-dependencies/>";
            string result = string.Empty;
            result += "<artifact-dependencies count=\"" + ArtifactDependency.Count + "\">";
            foreach (var item in ArtifactDependency)
            {
                result += "<artifact-dependency id=\"" + item.Id + "\" type=\"" + item.Type + "\">";
                result += item.Properties.GetAsXml();
                result += "</artifact-dependency>";
            }
            result += "</artifact-dependencies>";
            return result;
        }
    }
}