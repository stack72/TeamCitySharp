using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class InvestigationWrapper
  {
    [JsonProperty("investigation")]
    public List<Investigation> Investigation { get; set; }
  }
}