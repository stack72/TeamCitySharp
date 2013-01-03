using System;
using TeamCitySharp.Connection;

namespace TeamCitySharp.ActionTypes
{
    internal class BuildArtifacts: IBuildArtifacts
    {
        private TeamCityCaller _caller;

        public BuildArtifacts(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public void DownloadArtifactsByBuildId(string buildId, Action<string> downloadHandler)
        {
            _caller.GetDownloadFormat(downloadHandler, "/downloadArtifacts.html?buildId={0}", buildId);
        }
    }
}