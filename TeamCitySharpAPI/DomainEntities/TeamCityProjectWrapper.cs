using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharpAPI.DomainEntities
{
    public class TeamCityProjectWrapper
    {
        //This wrapper is required for JSON deserialising
        [JsonProperty(PropertyName = "project")]
        public List<Project> Projects { get; set; }
    }
}