using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
  public class Properties
  {
    public Properties()
    {
      Property = new List<Property>();
    }

    public void Add(string name, string value)
    {
      Property.Add(new Property(name, value));
    }

    public override string ToString()
    {
      return "properties";
    }

    public List<Property> Property { get; set; }
  }
}