namespace TeamCitySharp.DomainEntities
{
  public class InvesigationResolution
  {
    public string Type { get; set; }
  }

  public class Resolution
  {
    public const string WhenFixed = "whenFixed";
    public const string Manually = "manually";
  }
}