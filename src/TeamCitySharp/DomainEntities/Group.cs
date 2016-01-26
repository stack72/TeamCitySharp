namespace TeamCitySharp.DomainEntities
{
  public class Group
  {
    public override string ToString()
    {
      return Name;
    }

    public string Href { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }

    public UserWrapper Users { get; set; }
    public RoleWrapper Roles { get; set; }
  }
}