namespace TeamCitySharp.DomainEntities
{
  public class Project
  {
    public override string ToString()
    {
      return Name;
    }

    [JsonFx.Json.JsonName("archived")]
    public bool Archived { get; set; }
    [JsonFx.Json.JsonName("description")]
    public string Description { get; set; }
    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }
    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }
    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }
    [JsonFx.Json.JsonName("webUrl")]
    public string WebUrl { get; set; }

    [JsonFx.Json.JsonName("parentProject")]
    public Project ParentProject { get; set; }
    [JsonFx.Json.JsonName("buildTypes ")]
    public BuildTypeWrapper BuildTypes { get; set; }
    [JsonFx.Json.JsonName("parameters")]
    public Parameters Parameters { get; set; }
    [JsonFx.Json.JsonName("templates")]
    public Templates Templates { get; set; }
    [JsonFx.Json.JsonName("projects")]
    public ProjectWrapper Projects { get; set; }
    [JsonFx.Json.JsonName("projectFeatures")]
    public ProjectFeatures ProjectFeatures { get; set; }

  }
}