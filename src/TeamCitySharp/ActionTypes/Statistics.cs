using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public class Statistics : IStatistics
  {
    private readonly ITeamCityCaller m_caller;
    private string m_fields;

    internal Statistics(ITeamCityCaller caller)
    {
      m_caller = caller;
    }

    public Statistics GetFields(string fields)
    {
      var newInstance = (Statistics) MemberwiseClone();
      newInstance.m_fields = fields;
      return newInstance;
    }

    public Properties GetByBuildId(string buildId)
    {
      return m_caller.GetFormat<TeamCitySharp.DomainEntities.Properties>(ActionHelper.CreateFieldUrl("/builds/id:{0}/statistics", m_fields), buildId);
    }
  }
}