namespace TeamCitySharp.DomainEntities
{
  public class Template
  {
    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }

    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [JsonFx.Json.JsonName("projectId")]
    public string ProjectId { get; set; }

    [JsonFx.Json.JsonName("projectName")]
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