using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class File
  {
    [JsonProperty("relative-file")]
    public string Relativefile { get; set; }
  }
}