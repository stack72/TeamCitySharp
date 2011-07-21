using NUnit.Framework;
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