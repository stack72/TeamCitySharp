using System;

namespace TeamCitySharp
{
	public class ProjectRef
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }

        public override string ToString()
        {
            return Name;
        }
	}
}
