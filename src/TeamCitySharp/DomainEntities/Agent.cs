namespace TeamCitySharp.DomainEntities
{
  public class Agent
  {
    public string Name { get; set; }
    public string Id { get; set; }
    public string Href { get; set; }


    public override string ToString()
    {
      return Name;
    }
  }
}