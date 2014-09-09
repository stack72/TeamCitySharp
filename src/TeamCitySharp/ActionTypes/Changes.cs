using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class Changes : IChanges
    {
        private readonly TeamCityCaller _caller;

        internal Changes(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<Change> All(int aHttpTimeOut=-1)
        {
            if (aHttpTimeOut > -1)
                _caller.httpTimeOut = aHttpTimeOut;
            var changeWrapper = _caller.Get<ChangeWrapper>("/app/rest/changes");

            return changeWrapper.Change;
        }

        public Change ByChangeId(string id, int aHttpTimeOut = -1)
        {
            if (aHttpTimeOut > -1)
                _caller.httpTimeOut = aHttpTimeOut;
            var change = _caller.GetFormat<Change>("/app/rest/changes/id:{0}", id);

            return change;
        }

        public List<Change> ByBuildConfigId(string buildConfigId, int aHttpTimeOut = -1)
        {
            if (aHttpTimeOut > -1)
                _caller.httpTimeOut = aHttpTimeOut;
            var changeWrapper = _caller.GetFormat<ChangeWrapper>("/app/rest/changes?buildType={0}", buildConfigId);

            return changeWrapper.Change;
        }

        public Change LastChangeDetailByBuildConfigId(string buildConfigId, int aHttpTimeOut = -1)
        {
            if (aHttpTimeOut > -1)
                _caller.httpTimeOut = aHttpTimeOut;
            var changes = ByBuildConfigId(buildConfigId);

            return changes.FirstOrDefault();
        }

        public List<Change> ByBuild(Build aBuild, int aHttpTimeOut = -1)
        {
            int buildId;
            if (!int.TryParse(aBuild.Id, out buildId))
                buildId = -1;
            return ByBuildId(buildId, aHttpTimeOut);
        }

        public List<Change> ByBuildId(int aBuildId, int aHttpTimeOut = -1)
        {
            if (aHttpTimeOut > -1)
                _caller.httpTimeOut = aHttpTimeOut;
            var changeWrapper = _caller.GetFormat<ChangeWrapper>("/app/rest/changes?build=id:{0}", aBuildId);

            return changeWrapper.Change;
        }

    }
}
