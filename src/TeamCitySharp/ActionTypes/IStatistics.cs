using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public interface IStatistics
  {
    Statistics GetFields(string fields);
    Properties GetByBuildId(string buildId);
  }
}