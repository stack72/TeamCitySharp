using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Statistics
  {
    public Statistics()
    {
      Property = new List<Property>();
    }

    public void Add(string name, string value)
    {
      Property.Add(new Property(name, value));
    }

    public override string ToString()
    {
      return "statistics";
    }

    [JsonProperty("property")]
    public List<Property> Property { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }
  }
}