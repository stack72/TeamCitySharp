using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Test
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("mutes")]
    public List<Mutes> Mutes { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

  }
}