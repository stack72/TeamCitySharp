using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface IInvestigations
    {
        /// <summary>
        /// Returns investigation details about the test by its full name. In the format:
        /// MSTest: TestingNamespace.TestingClass.TestMethodName
        /// </summary>
        /// <param name="testLocator">TestLocator to indicate the test to get investigations for</param>
        /// <returns></returns>
        Investigation InvestigationByTest(TestLocator testLocator);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLocator"></param>
        /// <returns></returns>
        IList<Investigation> InvestinationsByUser(UserLocator userLocator);

        /// <summary>
        /// Returns investigation details for build configuration
        /// </summary>
        /// <param name="buildTypeLocator"></param>
        /// <returns></returns>
        IList<Investigation> InvestigationsByBuildConfiguration(BuildTypeLocator buildTypeLocator);
    }

    public class Investigations : IInvestigations
    {
        private readonly ITeamCityCaller _caller;

        internal Investigations(ITeamCityCaller caller)
        {
            _caller = caller;
        }

        public Investigation InvestigationByTest(TestLocator testLocator)
        {
            var investigationWrapper = _caller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=test:({0})", testLocator);

            if (investigationWrapper.Investigation == null || investigationWrapper.Investigation.Count == 0)
            {
                return null;
            }
            return investigationWrapper.Investigation[0];
        }

        public IList<Investigation> InvestinationsByUser(UserLocator userLocator)
        {
            var investigationWrapper = _caller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=assignee:({0})",
                userLocator);

            return investigationWrapper.Investigation ?? new List<Investigation>();
        }

        public IList<Investigation> InvestigationsByBuildConfiguration(BuildTypeLocator buildTypeLocator)
        {
            var investigationWrapper = _caller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=buildType:({0})",
                buildTypeLocator);

            return investigationWrapper.Investigation ?? new List<Investigation>();
        }
    }
}