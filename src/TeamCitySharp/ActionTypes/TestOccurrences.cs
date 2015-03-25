using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class TestOccurrences : ITestOccurrences
    {
        private readonly TeamCityCaller _caller;

        internal TestOccurrences(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<TestOccurrence> ByBuildId(string buildId, int count)
        {
            var testOccurenceWrapper = _caller.GetFormat<TestOccurrenceWrapper>("/app/rest/testOccurrences?locator=build:{0},count:{1}", buildId, count);

            return testOccurenceWrapper.TestOccurrence;
        }
    }
}
