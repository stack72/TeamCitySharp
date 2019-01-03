using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Revision
  {
    [JsonProperty("Version")]
    public string Version { get; set; }

    [JsonProperty("vcs-root-instance")]
    public VcsRoot VcsRootInstance { get; set; }


    public override string ToString()
    {
      return Version;
    }
  }
}
