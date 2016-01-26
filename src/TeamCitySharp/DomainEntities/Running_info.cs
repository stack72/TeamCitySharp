namespace TeamCitySharp.DomainEntities
{
  public class Running_info
  {
    public int? PercentageComplete { get; set; }
    public int? ElapsedSeconds { get; set; }
    public int? EstimatedTotalSeconds { get; set; }
    public string CurrentStageText { get; set; }
    public string Outdated { get; set; }
    public string ProbablyHanging { get; set; }
  }
}