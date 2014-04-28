using System.Collections.Generic;

using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class BuildSteps : IBuildSteps
    {
        private readonly TeamCityCaller _caller;


        public BuildSteps(TeamCityCaller caller)
        {
            _caller = caller;
        }


        public IList<BuildStep> ByConfigurationId(string buildConfigId)
        {
            var steps = _caller.Get<DomainEntities.BuildSteps>(string.Format("/app/rest/buildTypes/{0}/steps", buildConfigId));
            return steps.Step;
        }
    }
}