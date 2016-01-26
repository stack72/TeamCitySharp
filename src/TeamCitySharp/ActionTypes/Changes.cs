using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  internal class Changes : IChanges
  {
    private readonly ITeamCityCaller _caller;
    private string _fields;

    internal Changes(ITeamCityCaller caller)
    {
      _caller = caller;
    }

    public Changes GetFields(string fields)
    {
      var newInstance = (Changes) MemberwiseClone();
      newInstance._fields = fields;
      return newInstance;
    }

    public List<Change> All()
    {
      var changeWrapper = _caller.Get<ChangeWrapper>(ActionHelper.CreateFieldUrl("/app/rest/changes", _fields));

      return changeWrapper.Change;
    }

    public Change ByChangeId(string id)
    {
      var change = _caller.GetFormat<Change>(ActionHelper.CreateFieldUrl("/app/rest/changes/id:{0}", _fields), id);

      return change;
    }

    public List<Change> ByBuildConfigId(string buildConfigId)
    {
      var changeWrapper =
        _caller.GetFormat<ChangeWrapper>(ActionHelper.CreateFieldUrl("/app/rest/changes?buildType={0}", _fields),
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