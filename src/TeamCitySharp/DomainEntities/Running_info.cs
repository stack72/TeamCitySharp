namespace TeamCitySharp.DomainEntities
{
  public class Running_info
  {
    [JsonFx.Json.JsonName("percentageComplete")]
    public int? PercentageComplete { get; set; }

    [JsonFx.Json.JsonName("elapsedSeconds")]
    public int? ElapsedSeconds { get; set; }

    [JsonFx.Json.JsonName("estimatedTotalSeconds")]
    public int? EstimatedTotalSeconds { get; set; }

    [JsonFx.Json.JsonName("currentStageText")]
    public string CurrentStageText { get; set; }

    [JsonFx.Json.JsonName("outdated")]
    public string Outdated { get; set; }

    [JsonFx.Json.JsonName("probablyHanging")]
    public string ProbablyHanging { get; set; }
  }
}