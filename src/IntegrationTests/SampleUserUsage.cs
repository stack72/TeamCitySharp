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
            _client = new ClientSetup().Connect();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void it_returns_exception_when_no_host_specified()
        {
            var client = new TeamCityClient(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void it_returns_exception_when_host_does_not_exist()
        {
            var client = new TeamCityClient("test:81");
            client.Connect(ClientSetup.TeamCityClientUserName, ClientSetup.TeamCityClientPassword);

            var users = client.AllUsers();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void it_returns_exception_when_no_connection_made()
        {
            var client = new TeamCityClient(ClientSetup.TeamCityClientUrl);

            var users = client.AllUsers();

            //Assert: Exception
        }

        [Test]
        public void it_returns_all_user_groups()
        {
            List<Group> groups = _client.AllUserGroups();

            Assert.That(groups.Any(), "No user groups were found");
        }

        [Test]
        public void it_returns_all_users_by_user_group_name()
        {
            List<User> users = _client.AllUsersByUserGroup(ClientSetup.UserGroupName);

            Assert.That(users.Any(), "No users were found for this group");
        }

        [Test]
        public void it_returns_all_roles_by_user_group_name()
        {
            List<Role> roles = _client.AllUserRolesByUserGroup(ClientSetup.UserGroupName);

            Assert.That(roles.Any(), "No roles were found for that userGroup");
        }

        [Test]
        public void it_returns_all_users()
        {
            List<User> users = _client.AllUsers();

            Assert.That(users.Any(), "No users found for this server");
        }

        [Test]
        public void it_returns_all_users_by_user_name()
        {
            List<Role> roles = _client.AllRolesByUserName(ClientSetup.TeamCityClientUserName);
            
            Assert.That(roles.Any(), "No roles found for this user");
        }

        [Test]
        public void it_returns_all_user_groups_by_user_group_name()
        {
            List<Group> groups = _client.AllGroupsByUserName(ClientSetup.TeamCityClientUserName);

            Assert.That(groups.Any(), "This user is not a member of any groups");
        }
    }
}