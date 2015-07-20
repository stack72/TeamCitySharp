using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IChanges
    {
        List<Change> All();
        Change ByChangeId(long id);
        Change LastChangeDetailByBuildConfigId(string buildConfigId);
        List<Change> ByBuildConfigId(string buildConfigId);
        List<Change> ByBuildId(long buildId);
        List<Change> ByBuildIdWithDetails(long buildId);
    }
}