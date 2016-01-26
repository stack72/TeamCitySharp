using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public class Statistics : IStatistics
  {
    private readonly ITeamCityCaller _caller;
    private string _fields;

    internal Statistics(ITeamCityCaller caller)
    {
      _caller = caller;
    }

    public Statistics GetFields(string fields)
    {
      var newInstance = (Statistics) MemberwiseClone();
      newInstance._fields = fields;
      return newInstance;
    }

    public List<Property> GetByBuildId(string buildId)
    {
      return _caller.GetFormat<Properties>("/app/rest/builds/id:{0}/statistics", buildId).Property;
    }
  }
}