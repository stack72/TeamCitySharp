using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class ProjectWrapper
  {
    [JsonFx.Json.JsonName("project")]
    public List<Project> Project { get; set; }
  }
}