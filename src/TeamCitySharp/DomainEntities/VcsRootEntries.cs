using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class VcsRootEntries
  {
    public override string ToString()
    {
      return "vcs-root-entries";
    }

    public List<VcsRootEntry> VcsRootEntry { get; set; }
  }
}