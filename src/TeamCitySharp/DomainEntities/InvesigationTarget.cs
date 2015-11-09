namespace TeamCitySharp.DomainEntities
{
  public class InvesigationTarget
  {
    public Tests Tests { get; set; }
    public string AnyProblem { get; set; }
    public InvesigationResolution Resolution { get; set; }
  }
}