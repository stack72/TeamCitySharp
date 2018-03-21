using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class VcsRootEntries
  {
    public override string ToString()
    {
      return "vcs-root-entries";
    }


    [JsonFx.Json.JsonName("vcs-root-entry")]
    public List<VcsRootEntry> VcsRootEntry { get; set; }
  }
}