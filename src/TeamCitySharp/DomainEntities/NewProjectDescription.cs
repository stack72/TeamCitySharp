using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class NewProjectDescription
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("parentProject")]
    public ParentProjectWrapper ParentProject { get; set; }
  }
}