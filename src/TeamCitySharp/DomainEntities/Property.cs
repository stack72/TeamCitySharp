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

    public string Name { get; set; }
    public string Value { get; set; }
    public bool Inherited { get; set; }
  }
}