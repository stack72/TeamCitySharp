using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
