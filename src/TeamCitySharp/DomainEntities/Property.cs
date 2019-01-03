using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Property
  {
    public Property()
    {
    }

    public Property(string name, string value, bool inherited = false)
    {
      Name = name;
      Value = value;
      Inherited = inherited;
    }

    public override string ToString()
    {
      return Name;
    }

    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("value")]
    public string Value { get; set; }
    [JsonProperty("inherited")]
    public bool Inherited { get; set; }
  }
}