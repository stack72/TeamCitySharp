using Newtonsoft.Json;

namespace TeamCitySharpAPI.DomainEntities
{
    public class BuildConfig
    {
        public override string ToString()
        {
            return Name;
        }

        [JsonProperty(PropertyName = "paused")]
        public bool Paused { get; set; }
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
    }
}