namespace TeamCitySharp.DomainEntities
{
  public class Plugin
  {
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Version { get; set; }

    public override string ToString()
    {
      return DisplayName;
    }
  }
}