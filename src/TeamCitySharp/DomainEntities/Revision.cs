using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamCitySharp.DomainEntities
{
  public class Revision
  {
    public string Version { get; set; }
    public VcsRoot VcsRootInstance { get; set; }
    public override string ToString()
    {
      return Version;
    }
  }
}
