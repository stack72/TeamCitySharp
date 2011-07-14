using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI.Interfaces
{
    public interface TeamCityServer: ClientConnection
    {
        Server GetServerInfo();
    }
}
