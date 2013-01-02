using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IVcsRoots
    {
        List<VcsRoot> AllVcsRoots();
        VcsRoot VcsRootById(string vcsRootId);
    }
}