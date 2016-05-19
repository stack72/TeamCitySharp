namespace TeamCitySharp.DomainEntities
{
  public class VcsRootEntry
  {
    public override string ToString()
    {
      return "vcs-root-entry";
    }

    public VcsRoot VcsRoot { get; set; }
    public string CheckoutRules { get; set; }
  }
}