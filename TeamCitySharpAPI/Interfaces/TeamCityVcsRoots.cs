using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI.Interfaces
{
    public interface TeamCityVcsRoots: ClientConnection
    {
        List<VcsRoot> GetAllVcsRoots();
    }
}
