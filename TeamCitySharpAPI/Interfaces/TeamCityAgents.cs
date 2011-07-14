using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI.Interfaces
{
    public interface TeamCityAgents : ClientConnection
    {
        List<Agent> GetAllAgents();
    }
}