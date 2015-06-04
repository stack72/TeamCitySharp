using System;

namespace TeamCitySharp.DomainEntities.CCTray
{
    public class Project
    {
        public string Activity { get; set; }
        public int LastBuildLabel { get; set; }
        public string LastBuildStatus { get; set; }
        public DateTime LastBuildTime { get; set; }
        public string Name { get; set; }
        public string WebUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}