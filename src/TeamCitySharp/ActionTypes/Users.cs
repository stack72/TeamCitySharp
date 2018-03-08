using System.Collections.Generic;
using System.Net;
using EasyHttp.Http;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  internal class Users : IUsers
  {
    private readonly ITeamCityCaller m_caller;

    internal Users(ITeamCityCaller caller)
    {
      m_caller = caller;
    }

    public List<User> All()
    {
      var userWrapper = m_caller.Get<UserWrapper>("/app/rest/users");

      return userWrapper.User;
    }

    public List<Role> AllRolesByUserName(string userName)
    {
      var user =
        m_caller.GetFormat<User>("/app/rest/users/username:{0}", userName);

      return user.Roles.Role;
    }

    public User Details(string userName)
    {
      var user = m_caller.GetFormat<User>("/app/rest/users/username:{0}", userName);

      return user;
    }

    public List<Group> AllGroupsByUserName(string userName)
    {
      var user =
        m_caller.GetFormat<User>("/app/rest/users/username:{0}", userName);

      return user.Groups.Group;
    }

    public List<Group> AllUserGroups()
    {
      var userGroupWrapper = m_caller.Get<UserGroupWrapper>("/app/rest/userGroups");

      return userGroupWrapper.Group;
    }

    public List<User> AllUsersByUserGroup(string userGroupName)
    {
      var group = m_caller.GetFormat<Group>("/app/rest/userGroups/key:{0}", userGroupName);

      return group.Users.User;
    }

    public List<Role> AllUserRolesByUserGroup(string userGroupName)
    {
      var group = m_caller.GetFormat<Group>("/app/rest/userGroups/key:{0}", userGroupName);

      return group.Roles.Role;
    }

    public bool Create(string username, string name, string email, string password)
    {
      bool result = false;

      string data = $"<user name=\"{name}\" username=\"{username}\" email=\"{email}\" password=\"{password}\"/>";

      var createUserResponse = m_caller.Post(data, HttpContentTypes.ApplicationXml, "/app/rest/users", string.Empty);

      // Workaround, Create POST request fails to deserialize password field. See http://youtrack.jetbrains.com/issue/TW-23200
      // Also this does not return an accurate representation of whether it has worked or not
      AddPassword(username, password);

      if (createUserResponse.StatusCode == HttpStatusCode.OK)
        result = true;

      return result;
    }

    public bool AddPassword(string username, string password)
    {
      bool result = false;

      var response = m_caller.Put(password, HttpContentTypes.TextPlain,
        $"/app/rest/users/username:{username}/password", string.Empty);

      if (response.StatusCode == HttpStatusCode.OK)
        result = true;

      return result;
    }

    public bool IsAdministrator(string username)
    {
      var isAdministrator =
        m_caller.GetBoolean($"/app/rest/users/username:{username}/roles/SYSTEM_ADMIN/g");
      return isAdministrator;
    }
  }
}