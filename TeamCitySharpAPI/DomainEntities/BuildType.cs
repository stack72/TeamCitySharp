using Newtonsoft.Json;

namespace TeamCitySharpAPI
{
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