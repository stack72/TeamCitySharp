using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class Tags
  {
    public override string ToString()
    {
      return "tags";
    }

    public List<Tag> Tag { get; set; }
  }
}
