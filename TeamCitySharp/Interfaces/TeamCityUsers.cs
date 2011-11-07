using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI.Interfaces
{
    public interface TeamCityUsers: ClientConnection
    {
        List<User> GetAllUsers();
        List<Role> GetAllRolesForUserName(string userName);
        List<Group> GetAllGroupsByUserName(string userName);
    }
}