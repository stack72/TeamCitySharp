using System.Collections.Generic;

namespace TeamCitySharp.Locators
{
  public class TestLocator
  {
    public static TestLocator WithId(string id)
    {
      return new TestLocator { Id = id};
    }

    public static TestLocator WithName(string name)
    {
      return new TestLocator { Name = name};
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