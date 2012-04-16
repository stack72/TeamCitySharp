using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.DomainEntities
{
    public class Parameters
    {
        public override string ToString()
        {
            return "parameters";
        }

        public List<Property> Property { get; set; } 
    }
}
