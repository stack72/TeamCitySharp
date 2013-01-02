using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IUsers
    {
        List<User> AllUsers();
        List<Role> AllRolesByUserName(string userName);
        List<Group> AllGroupsByUserName(string userName);
        List<Group> AllUserGroups();
        List<User> AllUsersByUserGroup(string userGroupName);
        List<Role> AllUserRolesByUserGroup(string userGroupName);
        bool CreateUser(string username, string name, string email, string password);
        bool AddPassword(string username, string password);
    }
}