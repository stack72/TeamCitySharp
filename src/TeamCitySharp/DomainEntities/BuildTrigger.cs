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

    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [JsonFx.Json.JsonName("type")]
    public string Type { get; set; }

    [JsonFx.Json.JsonName("disabled")]
    public bool Disabled { get; set; }

    [JsonFx.Json.JsonName("inherited")]
    public bool Inherited { get; set; }

    [JsonFx.Json.JsonName("properties")]
    public Properties Properties { get; set; }



    public static BuildTrigger FinishBuildTrigger(string dependsOnbuildId)
    {
      var trigger = new BuildTrigger
        {
          Type = "buildDependencyTrigger"
        };

      trigger.Properties.Add("afterSuccessfulBuildOnly", "true");
      trigger.Properties.Add("dependsOn", dependsOnbuildId);

      return trigger;
    }
  }
}