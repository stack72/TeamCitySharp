using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Entry
  {
    public override string ToString()
    {
      return "entry";
    }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
  }
}
