using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public interface IStatistics
  {
    List<Property> GetByBuildId(string buildId);
  }
}