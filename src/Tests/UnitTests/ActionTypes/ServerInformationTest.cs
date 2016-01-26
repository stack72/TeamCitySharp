namespace TeamCitySharp.ActionTypes
{
  using FakeItEasy;
  using FluentAssertions;
  using NUnit.Framework;
  using TeamCitySharp.Connection;

  [TestFixture]
  public class ServerInformationTest
  {
    private ServerInformation testee;
    private ITeamCityCaller teamCityCaller;

    [SetUp]
    public void SetUp()
    {
      this.teamCityCaller = A.Fake<ITeamCityCaller>();
      this.testee = new ServerInformation(this.teamCityCaller);
    }

    [TestCase(true, true, true, true)]
    [TestCase(false, false, false, false)]
    [TestCase(true, false, false, false)]
    [TestCase(false, true, false, false)]
    [TestCase(false, false, true, false)]
    [TestCase(false, false, false, true)]
    public void CreatesBackupWithSelectedParts(bool includeBuildLogs, bool includeConfigurations, bool includeDatabase,
                                               bool includePersonalChanges)
    {
      const string Filename = "Filename";
      var backupOptions = new BackupOptions
        {
          Filename = Filename,
          IncludeBuildLogs = includeBuildLogs,
          IncludeConfigurations = includeConfigurations,
          IncludeDatabase = includeDatabase,
          IncludePersonalChanges = includePersonalChanges
        };

      this.testee.TriggerServerInstanceBackup(backupOptions);

      A.CallTo(() => this.teamCityCaller.StartBackup(string.Concat(
        "/app/rest/server/backup?fileName=",
        Filename,
        "&includeBuildLogs=" + includeBuildLogs,
        "&includeConfigs=" + includeConfigurations,
        "&includeDatabase=" + includeDatabase,
        "&includePersonalChanges=" + includePersonalChanges)))
       .MustHaveHappened();
    }

    [Test]
    public void GetsBackupStatus()
    {
      const string Status = "Idle";

      A.CallTo(() => this.teamCityCaller.GetRaw("/app/rest/server/backup")).Returns(Status);

      string status = this.testee.GetBackupStatus();

      status.Should().Be(Status);
    }
  }
}
