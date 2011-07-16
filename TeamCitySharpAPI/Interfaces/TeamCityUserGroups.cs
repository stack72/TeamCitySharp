using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI.Interfaces
{
    public interface TeamCityUserGroups: ClientConnection
    {
        List<Group> GetAllUserGroups();
        List<User> GetAllUsersByUserGroup(string userGroupName);
    }
}
