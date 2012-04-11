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
           
        }

        [Test]
        public void it_will_authenticate_a_known_user()
        {
            _client.Connect("admin", "qwerty");
            Assert.That(_client.IsAuthenticated);
        }

        [Test]
        [ExpectedException(typeof(AuthenticationException))]
        public void it_will_throw_an_exception_for_an_unknown_user()
        {
            _client.Connect("smithy", "smithy");
            
            //Assert.Throws Exception
        }

    }
}
