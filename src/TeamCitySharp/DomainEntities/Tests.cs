using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class Tests
  {
    [JsonFx.Json.JsonName("test")]
    public List<Test> Test { get; set; }
  }
}