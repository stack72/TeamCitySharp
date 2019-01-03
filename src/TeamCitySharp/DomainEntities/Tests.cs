using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Tests
  {
    [JsonProperty("test")]
    public List<Test> Test { get; set; }
  }
}