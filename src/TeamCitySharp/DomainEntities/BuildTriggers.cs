using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class BuildTriggers
    {
        public override string ToString()
        {
            return "triggers";
        }
        /// <summary>
        /// Lists of all the build triggers
        /// </summary>
        public List<BuildTrigger> Trigger { get; set; }
    }
}