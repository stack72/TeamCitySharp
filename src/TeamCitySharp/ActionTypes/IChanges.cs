using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface IChanges
    {
        List<Change> All();
        Change ByChangeId(string id);
        Change LastChangeDetailByBuildConfigId(string buildConfigId);
        List<Change> ByBuildConfigId(string buildConfigId);
        List<Change> ByBuildLocator(BuildLocator buildLocator);
    }
}