using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public interface IBuildInvestigations
  {
    List<Investigation> All();
    BuildInvestigations GetFields(string fields);
    List<Investigation> InvestigationsByBuildTypeId(string buildTypeId);
  }
}