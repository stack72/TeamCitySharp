using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Running_info
  {
    [JsonProperty("percentageComplete")]
    public int? PercentageComplete { get; set; }

    [JsonProperty("elapsedSeconds")]
    public int? ElapsedSeconds { get; set; }

    [JsonProperty("estimatedTotalSeconds")]
    public int? EstimatedTotalSeconds { get; set; }

    [JsonProperty("currentStageText")]
    public string CurrentStageText { get; set; }

    [JsonProperty("outdated")]
    public string Outdated { get; set; }

    [JsonProperty("probablyHanging")]
    public string ProbablyHanging { get; set; }
  }
}