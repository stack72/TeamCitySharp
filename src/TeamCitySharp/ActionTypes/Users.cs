using System.Collections.Generic;
using System.Net;
using EasyHttp.Http;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  internal class Users : IUsers
  {
    private readonly ITeamCityCaller _caller;

    internal Users(ITeamCityCaller caller)
    {
      _caller = caller;
    }

    public List<User> All()
    {
      var userWrapper = _caller.Get<UserWrapper>("/app/rest/users");

      return userWrapper.User;
    }

    public List<Role> AllRolesByUserName(string userName)
    {
      var user =
        _caller.GetFormat<User>("/app/rest/users/username:{0}", userName);

      return user.Roles.Role;
    }

    public User Details(string userName)
    {
      var user = _caller.GetFormat<User>("/app/rest/users/username:{0}", userName);

      return user;
    }

    public List<Group> AllGroupsByUserName(string userName)
    {
      var user =
        _caller.GetFormat<User>("/app/rest/users/username:{0}", userName);

      return user.Groups.Group;
    }

    public List<Group> AllUserGroups()
    {
      var userGroupWrapper = _caller.Get<UserGroupWrapper>("/app/rest/userGroups");

      return userGroupWrapper.Group;
    }

    public List<User> AllUsersByUserGroup(string userGroupName)
    {
      var group = _caller.GetFormat<Group>("/app/rest/userGroups/key:{0}", userGroupName);

      return group.Users.User;
    }

    public List<Role> AllUserRolesByUserGroup(string userGroupName)
    {
      var group = _caller.GetFormat<Group>("/app/rest/userGroups/key:{0}", userGroupName);

      return group.Roles.Role;
    }

    public bool Create(string username, string name, string email, string password)
    {
      bool result = false;

      string data = string.Format("<user name=\"{0}\" username=\"{1}\" email=\"{2}\" password=\"{3}\"/>", name, username,
                                  email, password);

      var createUserResponse = _caller.Post(data, HttpContentTypes.ApplicationXml, "/app/rest/users", string.Empty);

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

      var response = _caller.Put(password, HttpContentTypes.TextPlain,
                                 string.Format("/app/rest/users/username:{0}/password", username), string.Empty);

      if (response.StatusCode == HttpStatusCode.OK)
        result = true;

      return result;
    }

    public bool IsAdministrator(string username)
    {
      var isAdministrator =
        _caller.GetBoolean(string.Format("/app/rest/users/username:{0}/roles/SYSTEM_ADMIN/g", username));
      return isAdministrator;
    }
  }
}