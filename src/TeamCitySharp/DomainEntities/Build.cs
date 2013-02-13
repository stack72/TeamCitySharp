using System;

namespace TeamCitySharp.DomainEntities
{
    public class Build
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string BuildTypeId { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }
        public string StatusText { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public BuildConfig BuildConfig { get; set; }
        public Agent Agent { get; set;}
        public ChangeWrapper Changes { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}