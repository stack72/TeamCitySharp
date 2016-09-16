using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class Revisions
  {
    public int Count { get; set; }
    public List<Revision> Revision { get; set; }
  }
}
