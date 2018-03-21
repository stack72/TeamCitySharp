namespace TeamCitySharp.DomainEntities
{
  public class Agent
  {

    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }

    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }


    public override string ToString()
    {
      return Name;
    }
  }
}