using System.Security.Authentication;
using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_connecting_to_the_teamcity_server
  {
    private ITeamCityClient _client;

    [SetUp]
    public void SetUp()
    {
      _client = new TeamCityClient("localhost:81");
      _client = new TeamCityClient("vmmobuild01");
    }

    [Test]
    public void it_will_authenticate_a_known_user()
    {
      _client.Connect("admin", "qwerty");

      Assert.That(_client.Authenticate());
    }

    [Test]
    public void it_will_throw_an_exception_for_an_unknown_user()
    {
      _client.Connect("smithy", "smithy");
      Assert.Throws<AuthenticationException>(() => _client.Authenticate());
    }

    [Test]
    public void it_will_authenticate_a_known_user_throwExceptionOnHttpError()
    {
      _client.Connect("admin", "qwerty");

      Assert.That(_client.Authenticate(false));
    }

    [Test]
    public void it_will_throw_an_exception_for_an_unknown_user_throwExceptionOnHttpError()
    {
      _client.Connect("smithy", "smithy");
      Assert.IsFalse(_client.Authenticate(false));


      //Assert.Throws Exception
    }
  }
}