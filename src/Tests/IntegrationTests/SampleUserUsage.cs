using System;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using EasyHttp.Infrastructure;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_get_user_information
    {
        private ITeamCityClient m_client;
        private readonly string m_server;
        private readonly bool m_useSsl;
        private readonly string m_username;
        private readonly string m_password;


        public when_interacting_to_get_user_information()
        {
            m_server = ConfigurationManager.AppSettings["Server"];
            bool.TryParse(ConfigurationManager.AppSettings["UseSsl"], out m_useSsl);
            m_username = ConfigurationManager.AppSettings["Username"];
            m_password = ConfigurationManager.AppSettings["Password"];
        }

        [SetUp]
        public void SetUp()
        {
            m_client = new TeamCityClient(m_server, m_useSsl);
            m_client.Connect(m_username, m_password);
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
            var client = new TeamCityClient(m_server, m_useSsl);

            Assert.Throws<ArgumentException>(() => client.Users.All());
        }

        [Test]
        public void user_operation_throws_exception_for_unauthorized_user()
        {
            try
            {
                m_client.Users.All();
            }
            catch (HttpException e)
            {
                Assert.That(e.StatusCode == HttpStatusCode.Forbidden);
            }
            catch (Exception e)
            {
                Assert.Fail("Access all users by unauthorized user raised an unexpected exception", e);
            }
        }


        [Test, Ignore("Test user doesn't have the rights to access all user groups list.")]
        public void it_returns_all_user_groups()
        {
            List<Group> groups = m_client.Users.AllUserGroups();

            Assert.That(groups.Any(), "No user groups were found");
        }

        [Test, Ignore("Test user doesn't have the rights to access all users of a user group.")]
        public void it_returns_all_users_by_user_group_name()
        {
            string userGroupName = "ALL_USERS_GROUP";
            List<User> users = m_client.Users.AllUsersByUserGroup(userGroupName);

            Assert.That(users.Any(), "No users were found for this group");
        }

        [Test, Ignore("Test user doesn't have the rights to access all user roles by user group.")]
        public void it_returns_all_roles_by_user_group_name()
        {
            string userGroupName = "ALL_USERS_GROUP";
            List<Role> roles = m_client.Users.AllUserRolesByUserGroup(userGroupName);

            Assert.That(roles.Any(), "No roles were found for that userGroup");
        }

        [Test, Ignore("Test user doesn't have the rights to access all users.")]
        public void it_returns_all_users()
        {
            List<User> users = m_client.Users.All();

            Assert.That(users.Any(), "No users found for this server");
        }

        [Test, Ignore("Test user doesn't have the rights to access all roles of a user.")]
        public void it_returns_all_user_roles_by_user_name()
        {
            string userName = "teamcitysharpuser";
            List<Role> roles = m_client.Users.AllRolesByUserName(userName);

            Assert.That(roles.Any(), "No roles found for this user");
        }

        [Test]
        public void it_returns_all_user_groups_by_user_group_name()
        {
            string userName = m_username;
            List<Group> groups = m_client.Users.AllGroupsByUserName(userName);

            Assert.That(groups.Any(), "This user is not a member of any groups");
        }

        [Test]
        public void it_returns_user_details_by_user()
        {
            string userName = m_username;
            User details = m_client.Users.Details(userName);

            Assert.That(details.Email.ToLowerInvariant().Contains("@"), "Incorrect email address");
        }

        [Test]
        public void it_should_throw_exception_when_forbidden_status_code_returned()
        {
            var client = new TeamCityClient(m_server, m_useSsl);
            client.ConnectAsGuest();

            Assert.Throws<EasyHttp.Infrastructure.HttpException>(() => client.Users.All());
        }
    }
}