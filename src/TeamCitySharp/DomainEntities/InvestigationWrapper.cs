using System.Collections.Generic;
using TeamCitySharp.ActionTypes;

namespace TeamCitySharp.DomainEntities
{
    public class InvestigationWrapper
    {
        public string Count { get; set; }
        public List<Investigation> Investigation { get; set; } 
    }
}