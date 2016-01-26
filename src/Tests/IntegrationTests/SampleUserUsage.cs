using System;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_interacting_to_get_user_information
  {
    private ITeamCityClient _client;

    [SetUp]
    public void SetUp()
    {
      _client = new TeamCityClient("teamcity.codebetter.com");
      _client.Connect("teamcitysharpuser", "qwerty");
    }

    [Test]
    public void it_returns_exception_when_no_host_specified()
    {
      Assert.Throws<ArgumentNullException>(() => new TeamCityClient(null));
    }

    [Test]
    public void it_returns_exception_when_host_does_not_exist()
    {
      var client = new TeamCityClient("test:81");
      client.Connect("admin", "qwerty");

      Assert.Throws<WebException>(() => client.Users.All());
    }

    [Test]
    public void it_returns_exception_when_no_connection_made()
    {
      var client = new TeamCityClient("teamcity.codebetter.com");

      Assert.Throws<ArgumentException>(() => client.Users.All());
    }

    [Test]
    public void it_returns_all_user_groups()
    {
      List<Group> groups = _client.Users.AllUserGroups();

      Assert.That(groups.Any(), "No user groups were found");
    }

    [Test]
    public void it_returns_all_users_by_user_group_name()
    {
      string userGroupName = "ALL_USERS_GROUP";
      List<User> users = _client.Users.AllUsersByUserGroup(userGroupName);

      Assert.That(users.Any(), "No users were found for this group");
    }

    [Test]
    public void it_returns_all_roles_by_user_group_name()
    {
      string userGroupName = "ALL_USERS_GROUP";
      List<Role> roles = _client.Users.AllUserRolesByUserGroup(userGroupName);

      Assert.That(roles.Any(), "No roles were found for that userGroup");
    }

    [Test]
    public void it_returns_all_users()
    {
      List<User> users = _client.Users.All();

      Assert.That(users.Any(), "No users found for this server");
    }

    [Test]
    public void it_returns_all_user_roles_by_user_name()
    {
      string userName = "teamcitysharpuser";
      List<Role> roles = _client.Users.AllRolesByUserName(userName);

      Assert.That(roles.Any(), "No roles found for this user");
    }

    [Test]
    public void it_returns_all_user_groups_by_user_group_name()
    {
      string userName = "teamcitysharpuser";
      List<Group> groups = _client.Users.AllGroupsByUserName(userName);

      Assert.That(groups.Any(), "This user is not a member of any groups");
    }

    [Test]
    public void it_returns_user_details_by_user()
    {
      string userName = "teamcitysharpuser";
      User details = _client.Users.Details(userName);

      Assert.That(details.Email.ToLowerInvariant().Equals("teamcitysharp@paulstack.co.uk"), "Incorrect email address");
    }

    [Test]
    public void it_should_throw_exception_when_forbidden_status_code_returned()
    {
      var client = new TeamCityClient("localhost:81");
      client.ConnectAsGuest();

      Assert.Throws<Exception>(() => client.Users.All());

    }
  }
}