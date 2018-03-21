namespace TeamCitySharp.DomainEntities
{
  public class Tag
  {
    public override string ToString()
    {
      return "tag";
    }

    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }
  }
}
