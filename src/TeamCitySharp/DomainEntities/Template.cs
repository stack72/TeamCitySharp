namespace TeamCitySharp.DomainEntities
{
  public class Template
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Href { get; set; }
    public string ProjectId { get; set; }
    public string ProjectName { get; set; }

    public Template()
    {
      Id = "";
      Name = "";
      Href = "";
      ProjectId = "";
      ProjectName = "";
    }
  }
}