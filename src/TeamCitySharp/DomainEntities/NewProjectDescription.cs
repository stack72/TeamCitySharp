using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonFx.Json;
using TeamCitySharp.Locators;

namespace TeamCitySharp.DomainEntities
{
  public class NewProjectDescription
  {
    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }

    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("parentProject")]
    public ParentProjectWrapper ParentProject { get; set; }
  }
}