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

        public List<Change> All()
        {
            var changeWrapper = _caller.Get<ChangeWrapper>("/app/rest/changes");

            return changeWrapper.Change;
        }

        public Change ByChangeId(string id)
        {
            var change = _caller.GetFormat<Change>("/app/rest/changes/id:{0}", id);

            return change;
        }

        public List<Change> ByBuildConfigId(string buildConfigId)
        {
            var changeWrapper = _caller.GetFormat<ChangeWrapper>("/app/rest/changes?buildType={0}", buildConfigId);

            return changeWrapper.Change;
        }

        public Change LastChangeDetailByBuildConfigId(string buildConfigId)
        {
            var changes = ByBuildConfigId(buildConfigId);

            return changes.FirstOrDefault();
        }

    }
}