using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using TeamCitySharpAPI;
using TeamCitySharpAPI.DomainEntities;
using TeamCitySharpAPI.Interfaces;

namespace IntegrationTests
{
    [TestFixture]
    public class SampleUserGroupUsage
    {
        private TeamCityUserGroups _client;

        [SetUp]
        public void SetUp()
        {
            _client = new Client("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Instantiating_A_Client_Without_Host_Throws_Exception()
        {
            TeamCityUserGroups client = new Client(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void Instantiating_A_Client_With_A_Host_That_Doesnt_Exist_Throws_Exception()
        {
            TeamCityUserGroups client = new Client("test:81");
            client.Connect("admin", "qwerty");

            var userGroups = client.GetAllUserGroups();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Trying_To_Get_UserGroups_WithOut_Connecting_Throws_Exception()
        {
            TeamCityUserGroups client = new Client("localhost:81");

            var groups = client.GetAllUserGroups();

            //Assert: Exception
        }

        [Test]
        public void Get_All_User_Groups()
        {
            List<Group> groups = _client.GetAllUserGroups();

            Assert.That(groups.Any(), "No user groups were found");
        }

        [Test]
        public void Get_All_Users_By_User_Group_Name()
        {
            string userGroupName = "ALL_USERS_GROUP";
            List<User> users = _client.GetAllUsersByUserGroup(userGroupName);

            Assert.That(users.Any(), "No users were found for this group");
        }

        [Test]
        public void Get_All_Roles_By_User_Group_Name()
        {
            string userGroupName = "ALL_USERS_GROUP";
            List<Role> roles = _client.GetAllUserRolesByUserGroup(userGroupName);

            Assert.That(roles.Any(), "No roles were found for that userGroup");
        }
    }
}
