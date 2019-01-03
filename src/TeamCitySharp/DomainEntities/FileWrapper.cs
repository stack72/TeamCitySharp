using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class FileWrapper
  {
    [JsonProperty("file")]
    public List<File> File { get; set; }
  }
}