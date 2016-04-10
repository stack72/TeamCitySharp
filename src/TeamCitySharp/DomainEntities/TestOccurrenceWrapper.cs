using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class TestOccurrenceWrapper
    {
        public string Count { get; set; }
        public List<TestOccurrence> TestOccurrence { get; set; } 
    }
}