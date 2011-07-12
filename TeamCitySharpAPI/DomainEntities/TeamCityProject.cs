using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharpAPI
{
    //This wrapper is required for JSON deserialising
    public class TeamCityProjectWrapper
    {
        [JsonProperty(PropertyName = "project")]
        public List<TeamCityProject> Projects { get; set; }
    }

    public class TeamCityProject
    {
        public override string ToString()
        {
            return Name;
        }

        [JsonProperty(PropertyName = "archived")]
        public bool Archived { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "href")]
        public string Href { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty(PropertyName = "buildTypes")]
        public BuildTypeWrapper BuildTypes { get; set; }
    }

    public class BuildTypeWrapper
    {
        [JsonProperty(PropertyName = "buildType")]
        public List<BuildType> BuildTypes { get; set; }

    }

    public class BuildType
    {
        public override string ToString()
        {
            return Name;
        }

        [JsonProperty(PropertyName = "archived")]
        public bool Archived { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "href")]
        public string Href { get; set; }
        [JsonProperty(PropertyName = "projectId")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "projectName")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }
    }
}