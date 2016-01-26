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
    public string Name { get; set; }
    public string Id { get; set; }
    public ParentProjectWrapper ParentProject { get; set; }
  }
}