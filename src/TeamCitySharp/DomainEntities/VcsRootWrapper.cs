using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class VcsRootWrapper
  {
    [JsonFx.Json.JsonName("vcs-root")]
    public List<VcsRoot> VcsRoot { get; set; }
  }
}