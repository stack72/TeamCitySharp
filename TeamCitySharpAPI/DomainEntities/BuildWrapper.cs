using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharpAPI.DomainEntities
{
    public class BuildWrapper
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "build")]
        public List<Build> Builds { get; set; }
    }
}