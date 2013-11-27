using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class Artifacts
    {
        public override string ToString()
        {
            return "artifacts";
        }

        public List<Artifact> Files { get; set; }
    }
}
