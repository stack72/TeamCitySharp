using System;

namespace TeamCitySharp.DomainEntities
{
    public class Assignment
    {
        public User User { get; set; }
        public DateTime Timestamp { get; set; }
    }
}