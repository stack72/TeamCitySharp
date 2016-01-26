using System.Collections.Generic;

namespace TeamCitySharp.Locators
{
  public class ProjectLocator
  {
    public static ProjectLocator WithId(string id)
    {
      return new ProjectLocator {Id = id};
    }

    public static ProjectLocator WithName(string name)
    {
      return new ProjectLocator {Name = name};
    }

    public string Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
      if (!string.IsNullOrEmpty(Id))
        return "id:" + Id;

      if (!string.IsNullOrEmpty(Name))
        return "name:" + Name;


      var locatorFields = new List<string>();

      return string.Join(",", locatorFields.ToArray());
    }
  }
}