using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class VcsRoots: IVcsRoots
    {
        private readonly TeamCityCaller _caller;

        internal VcsRoots(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<VcsRoot> AllVcsRoots()
        {
            var vcsRootWrapper = _caller.Get<VcsRootWrapper>("/app/rest/vcs-roots");

            return vcsRootWrapper.VcsRoot;
        }

        public VcsRoot VcsRootById(string vcsRootId)
        {
            var vcsRoot = _caller.GetFormat<VcsRoot>("/app/rest/vcs-roots/id:{0}", vcsRootId);

            return vcsRoot;
        }

    }
}