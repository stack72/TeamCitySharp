using System;

namespace TeamCitySharp.DomainEntities
{
    public class VcsRoot
    {
        public string Id { get; set; }
        public string vcsName { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public DateTime lastChecked { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public Properties Properties { get; set; }
        public Project Project { get; set; }

    }
}