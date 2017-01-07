using System;

namespace TeamCitySharp.DomainEntities
{
    public class TriggeredInfo
    {
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public User User { get; set; }
    }
}
