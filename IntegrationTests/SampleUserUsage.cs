using System;
using System.Net;
using NUnit.Framework;
using TeamCitySharp;
using TeamCitySharpAPI;
using TeamCitySharpAPI.DomainEntities;
using TeamCitySharpAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationTests
{
    [TestFixture]
    public class SampleUserUsage
    {
        private TeamCityUsers _client;

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
            TeamCityUsers client = new Client(null);

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(WebException))]
        public void Instantiating_A_Client_With_A_Host_That_Doesnt_Exist_Throws_Exception()
        {
            TeamCityUsers client = new Client("test:81");
            client.Connect("admin", "qwerty");

            var users = client.GetAllUsers();

            //Assert: Exception
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Trying_To_Get_Users_WithOut_Connecting_Throws_Exception()
        {
            TeamCityUsers client = new Client("localhost:81");

            var users = client.GetAllUsers();

            //Assert: Exception
        }

        [Test]
        public void Get_All_Users()
        {
            List<User> users = _client.GetAllUsers();

            Assert.That(users.Any(), "No users found for this server");
        }

        [Test]
        public void Get_All_Roles_For_A_User_By_UserName()
        {
            string userName = "admin";
            List<Role> roles = _client.GetAllRolesForUserName(userName);
            
            Assert.That(roles.Any(), "No roles found for this user");
        }

        [Test]
        public void Get_All_Groups_That_A_User_Belongs_To()
        {
            string userName = "admin";
            List<Group> groups = _client.GetAllGroupsByUserName(userName);

            Assert.That(groups.Any(), "This user is not a member of any groups");
        }
        
    }
}