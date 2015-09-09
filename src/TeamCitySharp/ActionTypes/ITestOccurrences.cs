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

        /// <summary>
        /// Retrieves an instance of TestOccurence by Id as received from TeamCity API 
        /// </summary>
        /// <param name="testOccurenceLocator">In the format id=build:(id:181203),id:305</param>
        /// <returns></returns>
        TestOccurrence TestOccurrenceById(string testOccurenceLocator);

        /// <summary>
        /// Retrieve test history by id property on the test element from InvestigationsById API
        /// </summary>
        /// <param name="testId">In the format 8191545283982494536</param>
        /// <returns></returns>
        List<TestOccurrence> TestHistoryByTestId(string testId);
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

        /// <summary>
        /// Retrieves an instance of TestOccurence by Id as received from TeamCity API 
        /// </summary>
        /// <param name="testOccurenceLocator">In the format id=build:(id:181203),id:305</param>
        /// <returns></returns>
        public TestOccurrence TestOccurrenceById(string testOccurenceLocator)
        {
            var testOccurrence = _caller.GetFormat<TestOccurrence>("/app/rest/testOccurrences/{0}", testOccurenceLocator);

            return testOccurrence;
        }

        /// <summary>
        /// Retrieve test history by id property on the test element from InvestigationsById API
        /// </summary>
        /// <param name="testId">In the format 8191545283982494536</param>
        /// <returns></returns>
        public List<TestOccurrence> TestHistoryByTestId(string testId)
        {
            var testOccurrence = _caller.GetFormat<TestOccurrenceWrapper>("/app/rest/testOccurrences?locator=test:id:{0}", testId);

            return testOccurrence.TestOccurrence;
        }

        private static BuildLocator CreateBuildLocator(long buildId, int? indexStart, int? maxResults)
        {
            return BuildLocator.WithDimensions(buildId:buildId, startIndex:indexStart, maxResults: maxResults);
        }
    }
}