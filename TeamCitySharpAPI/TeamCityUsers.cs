using System.Collections.Generic;

namespace TeamCitySharpAPI
{
    public interface TeamCityUsers: ClientConnection
    {
        List<User> GetAllUsers();
    }
}