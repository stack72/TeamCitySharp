using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class VcsRootWrapper
  {
    [JsonProperty("vcs-root")]
    [JsonFx.Json.JsonName("vcs-root")]
    public List<VcsRoot> VcsRoot { get; set; }
  }
}