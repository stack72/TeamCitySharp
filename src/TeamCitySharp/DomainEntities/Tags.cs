using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Tags
  {
    public override string ToString()
    {
      return "tags";
    }
    [JsonProperty("tag")]
    public List<Tag> Tag { get; set; }
  }
}
