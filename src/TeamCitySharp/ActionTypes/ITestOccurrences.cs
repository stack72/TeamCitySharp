using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface ITestOccurrences
    {
        List<TestOccurrence> ByBuildId(string buildId, int count);
    }
}