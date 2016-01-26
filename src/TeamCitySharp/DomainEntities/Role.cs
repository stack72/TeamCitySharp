namespace TeamCitySharp.DomainEntities
{
  public class Role
  {
    public string Href { get; set; }
    public string Scope { get; set; }
    public string RoleId { get; set; }

    public override string ToString()
    {
      return RoleId;
    }
  }
}