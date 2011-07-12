using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharpAPI.DomainEntities
{
    public class BuildType
    {
        [JsonProperty(PropertyName = "buildType")]
        public List<Build> Builds { get; set; }

    }
}