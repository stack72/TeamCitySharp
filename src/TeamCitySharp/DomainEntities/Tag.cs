using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Tag
  {
    public override string ToString()
    {
      return "tag";
    }

    [JsonProperty("name")]
    public string Name { get; set; }
  }
}
