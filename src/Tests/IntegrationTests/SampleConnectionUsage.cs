using System.Configuration;
using System.Security.Authentication;
using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_connecting_to_the_teamcity_server
  {
    private ITeamCityClient m_client;
    private readonly string m_server;
    private readonly bool m_useSsl;
    private readonly string m_username;
    private readonly string m_password;


    public when_connecting_to_the_teamcity_server()
    {
      m_server = ConfigurationManager.AppSettings["Server"];
      bool.TryParse(ConfigurationManager.AppSettings["UseSsl"], out m_useSsl);
      m_username = ConfigurationManager.AppSettings["Username"];
      m_password = ConfigurationManager.AppSettings["Password"];
    }

    [SetUp]
    public void SetUp()
    {
      m_client = new TeamCityClient(m_server,m_useSsl);
    }

    [Test]
    public void it_will_authenticate_a_known_user()
    {
      m_client.Connect(m_username,m_password);

      Assert.That(m_client.Authenticate());
    }

    [Test]
    public void it_will_throw_an_exception_for_an_unknown_user()
    {
      m_client.Connect("smithy", "smithy");
      Assert.Throws<AuthenticationException>(() => m_client.Authenticate());
    }

    [Test]
    public void it_will_authenticate_a_known_user_throwExceptionOnHttpError()
    {
      m_client.Connect(m_username, m_password);

      Assert.That(m_client.Authenticate(false));
    }

    [Test]
    public void it_will_throw_an_exception_for_an_unknown_user_throwExceptionOnHttpError()
    {
      m_client.Connect("smithy", "smithy");
      Assert.IsFalse(m_client.Authenticate(false));


      //Assert.Throws Exception
    }
  }
}