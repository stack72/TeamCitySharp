using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IChanges
    {
        List<Change> All(int aHttpTimeOut = -1);
        Change ByChangeId(string id, int aHttpTimeOut = -1);
        Change LastChangeDetailByBuildConfigId(string buildConfigId, int aHttpTimeOut = -1);
        List<Change> ByBuildConfigId(string buildConfigId, int aHttpTimeOut = -1);
        List<Change> ByBuild(Build aBuild, int aHttpTimeOut = -1);
        List<Change> ByBuildId(int aBuildId, int aHttpTimeOut = -1);
    }
}
