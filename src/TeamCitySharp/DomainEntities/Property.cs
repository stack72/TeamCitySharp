namespace TeamCitySharp.DomainEntities
{
  public class Property
  {
    public Property()
    {
    }

    public Property(string name, string value)
    {
      Name = name;
      Value = value;
    }

    public override string ToString()
    {
      return Name;
    }

    public string Name { get; set; }
    public string Value { get; set; }
  }
}