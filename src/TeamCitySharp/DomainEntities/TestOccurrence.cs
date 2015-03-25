using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.DomainEntities
{
    public class TestOccurrence
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int Duration { get; set; }
        public bool Muted { get; set; }
        public bool Ignored { get; set; }
        public string Href { get; set; }
    }
}
