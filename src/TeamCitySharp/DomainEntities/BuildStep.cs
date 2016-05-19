namespace TeamCitySharp.DomainEntities
{
  public class BuildStep
  {
    public override string ToString()
    {
      return "step";
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Disabled { get; set; }
    public Properties Properties { get; set; }
  }
}