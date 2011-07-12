using System.Collections.Generic;
using Newtonsoft.Json;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public class BuildDetail
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "build")]
        public List<Build> Build { get; set; }
    }
}