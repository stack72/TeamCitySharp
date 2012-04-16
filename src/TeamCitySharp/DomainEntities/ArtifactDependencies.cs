using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.DomainEntities
{
    public class ArtifactDependencies
    {
        public override string ToString()
        {
            return "artifact-dependencies";
        }

        public List<ArtifactDependency> ArtifactDependency { get; set; }
    }
}
