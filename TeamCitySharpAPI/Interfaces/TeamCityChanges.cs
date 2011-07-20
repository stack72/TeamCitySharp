using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI.Interfaces
{
    public interface TeamCityChanges: ClientConnection
    {
        List<Change> GetAllChanges();
        Change GetChangeDetailsByChangeId(string id);
    }
}