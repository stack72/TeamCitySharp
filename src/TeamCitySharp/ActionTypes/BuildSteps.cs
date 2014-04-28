using System.Collections.Generic;

using EasyHttp.Http;

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


        public void Create(string buildConfigId, BuildStep buildStep)
        {
            string url = string.Format("/app/rest/buildTypes/{0}/steps", buildConfigId);
            _caller.Post(buildStep, HttpContentTypes.ApplicationJson, url, HttpContentTypes.ApplicationJson);
        }
    }
}