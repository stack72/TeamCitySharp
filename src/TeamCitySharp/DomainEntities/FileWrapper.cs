using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class FileWrapper
  {
    [JsonFx.Json.JsonName("file")]
    public List<File> File { get; set; }
  }
}