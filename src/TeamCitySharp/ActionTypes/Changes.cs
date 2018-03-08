using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  internal class Changes : IChanges
  {
    private readonly ITeamCityCaller m_caller;
    private string m_fields;

    internal Changes(ITeamCityCaller caller)
    {
      m_caller = caller;
    }

    public Changes GetFields(string fields)
    {
      var newInstance = (Changes) MemberwiseClone();
      newInstance.m_fields = fields;
      return newInstance;
    }

    public List<Change> All()
    {
      var changeWrapper = m_caller.Get<ChangeWrapper>(ActionHelper.CreateFieldUrl("/app/rest/changes", m_fields));

      return changeWrapper.Change;
    }

    public Change ByChangeId(string id)
    {
      var change = m_caller.GetFormat<Change>(ActionHelper.CreateFieldUrl("/app/rest/changes/id:{0}", m_fields), id);

      return change;
    }

    public List<Change> ByBuildConfigId(string buildConfigId)
    {
      var changeWrapper =
        m_caller.GetFormat<ChangeWrapper>(ActionHelper.CreateFieldUrl("/app/rest/changes?buildType={0}", m_fields),
                                         buildConfigId);

      return changeWrapper.Change;
    }

    public Change LastChangeDetailByBuildConfigId(string buildConfigId)
    {
      var changes = ByBuildConfigId(buildConfigId);

      return changes.FirstOrDefault();
    }
  }
}