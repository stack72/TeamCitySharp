using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class Parameters
  {
    public override string ToString()
    {
      return "parameters";
    }
    [JsonFx.Json.JsonName("property")]
    public List<Property> Property { get; set; }
  }
}