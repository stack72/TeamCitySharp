using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Templates
  {
    [JsonProperty("buildType")]
    public List<Template> BuildType { get; set; }
  }
}