using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class InvestigationWrapper
  {
    [JsonFx.Json.JsonName("investigation")]
    public List<Investigation> Investigation { get; set; }
  }
}