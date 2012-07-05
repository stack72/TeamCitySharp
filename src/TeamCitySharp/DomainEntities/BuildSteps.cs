using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.DomainEntities
{
    public class BuildSteps
    {
        public override string ToString()
        {
            return "steps";
        }
        /// <summary>
        /// Lists of all the build steps.
        /// </summary>
        public List<BuildStep> Step { get; set; }
    }
}
