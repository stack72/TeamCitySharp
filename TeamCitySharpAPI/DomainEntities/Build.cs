using Newtonsoft.Json;

namespace TeamCitySharpAPI.DomainEntities
{
    public class Build
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "number")]
        public string Version { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "buildTypeId")]
        public string BuildTypeId { get; set; }
        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }
    }
}
