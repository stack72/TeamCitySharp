using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharpAPI
{
    public class BuildTypeWrapper
    {
        [JsonProperty(PropertyName = "buildType")]
        public List<BuildType> BuildTypes { get; set; }

    }
}