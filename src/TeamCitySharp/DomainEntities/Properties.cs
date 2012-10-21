using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class Properties
    {
        public override string ToString()
        {
            return "properties";
        }
        public List<Property> Property { get; set; }
    }
}