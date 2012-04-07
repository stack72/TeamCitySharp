using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class BuildWrapper
    {
        public string Count { get; set; }
        public List<BuildRef> Build { get; set; }
    }
}