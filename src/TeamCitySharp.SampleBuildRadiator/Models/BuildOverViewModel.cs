using System;

namespace TeamCitySharp.SampleBuildRadiator.Models
{
    public class BuildOverViewModel
    {
        public string ProjectName { get; set; }
        public string BuildName { get; set; }
        public DateTime LastBuildDate { get; set; }
        public string LastStatus { get; set; }
    }
}