using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Project
  {
    public override string ToString()
    {
      return Name;
    }

    [JsonProperty("archived")]
    public bool Archived { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("href")]
    public string Href { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("webUrl")]
    public string WebUrl { get; set; }
    [JsonProperty("parentProject")]
    public Project ParentProject { get; set; }
    [JsonProperty("buildTypes")]
    public BuildTypeWrapper BuildTypes { get; set; }
    [JsonProperty("parameters")]
    public Parameters Parameters { get; set; }
    [JsonProperty("templates")]
    public Templates Templates { get; set; }
    [JsonProperty("projects")]
    public ProjectWrapper Projects { get; set; }
    [JsonProperty("projectFeatures")]
    public ProjectFeatures ProjectFeatures { get; set; }

  }
}