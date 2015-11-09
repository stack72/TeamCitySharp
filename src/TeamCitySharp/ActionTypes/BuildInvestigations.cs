using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  internal class BuildInvestigations : IBuildInvestigations
  {
    private readonly ITeamCityCaller _caller;

    internal BuildInvestigations(ITeamCityCaller caller)
    {
      _caller = caller;
    }

    #region IBuildInvestigations Members

    public List<Investigation> All()
    {
      var url = string.Format("/app/rest/investigations");

      var wrapper = _caller.Get<InvestigationWrapper>(url);

      return wrapper.Investigation;
    }

    public List<Investigation> InvestigationsByBuildTypeId(string buildTypeId)
    {
      var investigationsByBuildTypeId = new List<Investigation>();
      var investigations = All();

      foreach (var investigation in investigations)
      {
        if (investigation.Scope != null && investigation.Scope.BuildTypes != null)
        {
          foreach (var buildType in investigation.Scope.BuildTypes.BuildType)
          {
            if (buildType.Id.Equals(buildTypeId))
            {
              investigationsByBuildTypeId.Add(investigation);
            }
          }
        }
      }

      return investigationsByBuildTypeId;
    }

    #endregion
  }

}
