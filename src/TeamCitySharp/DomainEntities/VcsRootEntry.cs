namespace TeamCitySharp.DomainEntities
{
  public class VcsRootEntry
  {
    public override string ToString()
    {
      return "vcs-root-entry";
    }

    [JsonFx.Json.JsonName("vcs-root")]
    public VcsRoot VcsRoot { get; set; }

    [JsonFx.Json.JsonName("checkout-rules")]
    public string CheckoutRules { get; set; }
  }
}