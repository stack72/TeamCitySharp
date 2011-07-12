using System.Collections.Generic;
using Newtonsoft.Json;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public class BuildConfig
    {
        [JsonProperty(PropertyName = "buildType" )]
        public List<Build> Builds { get; set; }
    }
}