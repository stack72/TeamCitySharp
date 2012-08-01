using NUnit.Framework;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interacting_to_start_build_in_system_functions
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("localhost:81");
            _client.Connect("admin", "qwerty");
        }

        [Test]
        public void triggering_a_backup_works_as_expected()
        {
            var backup = _client.TriggerServerInstanceBackup("integration-test");

            Assert.IsTrue(backup);
        }
    }
}
