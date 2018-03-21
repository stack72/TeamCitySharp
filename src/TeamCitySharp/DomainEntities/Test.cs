namespace TeamCitySharp.DomainEntities
{
  public class Test
  {
    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }
  }
}