using System;

namespace TeamCitySharp
{
	public class BuildRef
	{
        public string Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string BuildTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }

        public override string ToString()
        {
            return Number;
		}
	}
}
