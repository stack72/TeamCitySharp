using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharpAPI
{
    public class TeamCityProjectWrapper
    {
        //This wrapper is required for JSON deserialising
        [JsonProperty(PropertyName = "project")]
        public List<TeamCityProject> Projects { get; set; }
    }
}