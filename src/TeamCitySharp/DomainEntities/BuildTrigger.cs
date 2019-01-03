using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class BuildTrigger
  {
    public BuildTrigger()
    {
      Properties = new Properties();
    }

    public override string ToString()
    {
      return "trigger";
    }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("disabled")]
    public bool Disabled { get; set; }

    [JsonProperty("inherited")]
    public bool Inherited { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }



    public static BuildTrigger FinishBuildTrigger(string dependsOnBuildId)
    {
      var trigger = new BuildTrigger
        {
          Type = "buildDependencyTrigger"
        };

      trigger.Properties.Add("afterSuccessfulBuildOnly", "true");
      trigger.Properties.Add("dependsOn", dependsOnBuildId);

      return trigger;
    }
  }
}