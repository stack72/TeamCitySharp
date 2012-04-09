using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildMonitor.Models
{
    public class ProjectModel
    {
        public string ProjectName { get; set; }
        public string ProjectId { get; set; }
        public string BuildConfigName { get; set; }
        public string LastBuildTime { get; set; }
        public string LastBuildStatus { get; set; }
        public string LastBuildStatusText { get; set; }
        
    }
}