using System;
using System.Collections.Generic;
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
    private ITeamCityClient _client;

    [SetUp]
    public void SetUp()
    {
      _client = new TeamCityClient("teamcity.codebetter.com");
      _client.Connect("teamcitysharpuser", "qwerty");
    }

    [Test]
    public void it_will_add_a_new_user_and_new_user_will_be_able_to_log_in()
    {
      string userName = "John.Doe";
      string name = "John Doe";
      string email = "John.Doe@test.com";
      string password = "J0hnD03";

      var createUserResult = _client.Users.Create(userName, name, email, password);

      ITeamCityClient _newUser;
      _newUser = new TeamCityClient("teamcity.codebetter.com");
      _newUser.Connect(userName, password);

      var loginResponse = _newUser.Authenticate();

      Assert.That(createUserResult && loginResponse);
    }
  }
}