using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface ITestOccurrences
    {
        List<TestOccurrence> TestOccurrencesByBuildId(long buildId, int? indexStart = 0, int? maxResults = 100);
        List<TestOccurrence> FailedTestOccurrencesByBuildId(long buildId, int? indexStart = 0, int? maxResults = 100);
    }

    public class TestOccurrences : ITestOccurrences
    {
        private readonly TeamCityCaller _caller;

        internal TestOccurrences(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<TestOccurrence> TestOccurrencesByBuildId(long buildId, int? indexStart = 0, int? maxResults = 100)
        {
            var testOccurrenceWrapper = _caller.GetFormat<TestOccurrenceWrapper>("/app/rest/testOccurrences?locator=build:{0}",
                CreateBuildLocator(buildId, indexStart, maxResults));

            if (int.Parse(testOccurrenceWrapper.Count) > 0)
            {
                return testOccurrenceWrapper.TestOccurrence;
            }

            return new List<TestOccurrence>();
        }

        public List<TestOccurrence> FailedTestOccurrencesByBuildId(long buildId, int? indexStart = 0, int? maxResults = 100)
        {
            var testOccurrenceWrapper = _caller.GetFormat<TestOccurrenceWrapper>("/app/rest/testOccurrences?locator=build:{0},status:FAILURE",
                CreateBuildLocator(buildId, indexStart, maxResults));

            if (int.Parse(testOccurrenceWrapper.Count) > 0)
            {
                return testOccurrenceWrapper.TestOccurrence;
            }

            return new List<TestOccurrence>();
        }

        private static BuildLocator CreateBuildLocator(long buildId, int? indexStart, int? maxResults)
        {
            return BuildLocator.WithDimensions(buildId:buildId, startIndex:indexStart, maxResults: maxResults);
        }
    }
}