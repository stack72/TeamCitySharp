using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class VcsRootEntries
  {
    public override string ToString()
    {
      return "vcs-root-entries";
    }

    [JsonProperty("vcs-root-entry")]
    public List<VcsRootEntry> VcsRootEntry { get; set; }
  }
}