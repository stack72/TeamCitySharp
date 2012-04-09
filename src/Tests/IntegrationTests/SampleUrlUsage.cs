using NUnit.Framework;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    public class when_making_calls_to_the_api_using_a_url
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        [Test]
        public void it_should_have_a_null_status_text_on_the_build_object_when_using_build_locator()
        {
            var build = _client.CallByUrl<Build>("/app/rest/builds?locator=buildType:(id:bt5),count:1");

            Assert.That(build.GetType() == typeof(Build));
            Assert.IsNull(build.StatusText);
        }

        [Test]
        public void it_should_have_status_text_on_the_build_object_when_using_non_build_locator_call()
        {
            var build = _client.CallByUrl<Build>("/app/rest/buildTypes/id:bt5/builds/id:32");

            Assert.That(build.GetType() == typeof(Build));
            Assert.IsNotNullOrEmpty(build.StatusText);
        }

    }
}
