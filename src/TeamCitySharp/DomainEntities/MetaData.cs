using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class MetaData
  {
    public override string ToString()
    {
      return "metaData";
    }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("entries")]
    public Entries Entries { get; set; }
  }
}
