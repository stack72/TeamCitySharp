using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  [Ignore("ignore")]
  public class when_team_city_client_is_asked_to_create_a_new_user_with_a_password
  {
    private ITeamCityClient m_client;
    private readonly string m_server;
    private readonly bool m_useSsl;
    private readonly string m_username;
    private readonly string m_password;


    public when_team_city_client_is_asked_to_create_a_new_user_with_a_password()
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
    public void it_will_add_a_new_user_and_new_user_will_be_able_to_log_in()
    {
      string userName = "John.Doe";
      string name = "John Doe";
      string email = "John.Doe@test.com";
      string password = "J0hnD03";

      var createUserResult = m_client.Users.Create(userName, name, email, password);

      ITeamCityClient _newUser;
      _newUser = new TeamCityClient(m_server, m_useSsl);
      _newUser.Connect(userName, password);

      var loginResponse = _newUser.Authenticate();

      Assert.That(createUserResult && loginResponse);
    }
  }
}