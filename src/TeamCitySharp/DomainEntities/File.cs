namespace TeamCitySharp.DomainEntities
{
  public class File
  {
    [JsonFx.Json.JsonName("relative-file")]
    public string Relativefile { get; set; }
  }
}