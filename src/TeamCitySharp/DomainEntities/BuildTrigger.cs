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

    public string Id { get; set; }
    public string Type { get; set; }
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