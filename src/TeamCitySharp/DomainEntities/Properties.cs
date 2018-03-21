using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TeamCitySharp.DomainEntities
{
  [DataContract]
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

    [DataMember]
    [JsonFx.Json.JsonName("property")]
    public List<Property> Property { get; set; }
  }
}