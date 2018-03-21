namespace TeamCitySharp.DomainEntities
{
  public class Revision
  {
    [JsonFx.Json.JsonName("Version")]
    public string Version { get; set; }

    [JsonFx.Json.JsonName("vcs-root-instance")]
    public VcsRoot VcsRootInstance { get; set; }


    public override string ToString()
    {
      return Version;
    }
  }
}
