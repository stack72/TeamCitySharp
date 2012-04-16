using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.DomainEntities
{
    public class Property
    {
        public override string ToString()
        {
            return Name;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}

