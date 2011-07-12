using Newtonsoft.Json;

namespace TeamCitySharpAPI.DomainEntities
{
    public class Build
    {
        public override string ToString()
        {
            return Name;
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "href")]
        public string Href { get; set; }
        [JsonProperty(PropertyName = "projectId")]
        public string ProjectId { get; set; }
        [JsonProperty(PropertyName = "projectName")]
        public string ProjectName { get; set; }
        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }
    }
}