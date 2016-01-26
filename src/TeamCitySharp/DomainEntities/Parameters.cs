using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class Parameters
  {
    public override string ToString()
    {
      return "parameters";
    }

    public List<Property> Property { get; set; }
  }
}