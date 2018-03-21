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

    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }
    [JsonFx.Json.JsonName("value")]
    public string Value { get; set; }
    [JsonFx.Json.JsonName("inherited")]
    public bool Inherited { get; set; }
  }
}