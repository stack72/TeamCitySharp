using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IChanges
    {
        List<Change> AllChanges();
        Change ChangeDetailsByChangeId(string id);
        Change LastChangeDetailByBuildConfigId(string buildConfigId);
        List<Change> ChangeDetailsByBuildConfigId(string buildConfigId);
    }
}