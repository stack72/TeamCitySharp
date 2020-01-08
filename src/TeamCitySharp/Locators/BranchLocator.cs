using System.Collections.Generic;

namespace TeamCitySharp.Locators
{
  public enum BranchPolicy
  {
    VCS_BRANCHES,
    ACTIVE_VCS_BRANCHES,
    HISTORY_BRANCHES,
    ACTIVE_HISTORY_BRANCHES,
    ACTIVE_HISTORY_AND_ACTIVE_VCS_BRANCHES,
    ALL_BRANCHES
  }

  public class BranchLocator
  {
    public static BranchLocator WithDimensions(BranchPolicy? policy = null)
    {
      return new BranchLocator
      {
        Policy = policy
      };
    }

    public BranchPolicy? Policy { get; private set; }

    public override string ToString()
    {
      var locatorFields = new List<string>();
      if (Policy.HasValue)
        locatorFields.Add("policy:" + Policy.Value.ToString());
      return string.Join(",", locatorFields.ToArray());
    }
  }
}
