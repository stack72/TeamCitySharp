using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Test
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
  }
}