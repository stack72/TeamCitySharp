using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Template
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("projectId")]
    public string ProjectId { get; set; }

    [JsonProperty("projectName")]
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