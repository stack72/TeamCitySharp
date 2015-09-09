using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IInvestigations
    {
        /// <summary>
        /// Get investigation details about the test by its full name. 
        /// </summary>
        /// <param name="testId">Id in the long numberic format. TestOccurence.Test.Id</param>
        /// <returns></returns>
        List<Investigation> InvestigationsById(string testId);

        /// <summary>
        /// Get investigation details about the test by its full name. In the format:
        /// MSTest: TestingNamespace.TestingClass.TestMethodName
        /// </summary>
        /// <param name="testName">Test name in the format: 'MSTest: TestingNamespace.TestingClass.TestMethodName'</param>
        /// <returns></returns>
        List<Investigation> InvestigationsByName(string testName);
    }

    public class Investigations : IInvestigations
    {
        private readonly ITeamCityCaller _caller;

        internal Investigations(ITeamCityCaller caller)
        {
            _caller = caller;
        }

        /// <summary>
        /// Get investigation details about the test by its full name. 
        /// </summary>
        /// <param name="testId">Id in the long numberic format. TestOccurence.Test.Id</param>
        /// <returns></returns>
        public List<Investigation> InvestigationsById(string testId)
        {
            var investigationWrapper = _caller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=test:(id:{0})", testId);

            return investigationWrapper.Investigation;
        }

        /// <summary>
        /// Get investigation details about the test by its full name. In the format:
        /// MSTest: TestingNamespace.TestingClass.TestMethodName
        /// </summary>
        /// <param name="testName">Test name in the format: 'MSTest: TestingNamespace.TestingClass.TestMethodName'</param>
        /// <returns></returns>
        public List<Investigation> InvestigationsByName(string testName)
        {
            var investigation = _caller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=test:(name:{0})", testName);

            return investigation.Investigation;
        }
    }
}