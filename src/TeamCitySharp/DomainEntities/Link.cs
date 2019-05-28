using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Link
  {
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("relativeUrl")]
    public string RelativeUrl { get; set; }
  }
}