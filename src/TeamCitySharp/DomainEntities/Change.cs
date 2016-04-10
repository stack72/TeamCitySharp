﻿using System;

namespace TeamCitySharp.DomainEntities
{
    public class Change
    {
        public string Username { get; set; }
        public string WebLink { get; set; }
        public string Href { get; set; }
        public long Id { get; set; }
        public string Version { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public FileWrapper Files { get; set; }

        public User User { get; set; }
    }
}