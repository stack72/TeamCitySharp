using FakeItEasy;
using NUnit.Framework;
using TeamCitySharp.ActionTypes;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.Tests.ActionTypes
{
    [TestFixture]
    public class InvestigationsTests
    {
        [Test]
        public void InvestigationById_Id_GetFormatCalled()
        {
            // Arrange
            var teamCityCaller = A.Fake<ITeamCityCaller>();
            var buildConfigs = new Investigations(teamCityCaller);

            // Act
            buildConfigs.InvestigationByTest(TestLocator.WithId("123"));

            // Assert
            A.CallTo(
                () =>
                    teamCityCaller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=test:({0})",
                        A<TestLocator>.That.Matches(l => l.Id == "123"))).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void InvestigationByName_Name_GetFormatCalled()
        {
            // Arrange
            var teamCityCaller = A.Fake<ITeamCityCaller>();
            var buildConfigs = new Investigations(teamCityCaller);

            // Act
            buildConfigs.InvestigationByTest(TestLocator.WithName("test name"));

            // Assert
            A.CallTo(
                () =>
                    teamCityCaller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=test:({0})",
                        A<TestLocator>.That.Matches(l => l.Name == "test name"))).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void InvestigationsByBuildConfiguration_Name_GetFormatCalled()
        {
            // Arrange
            var teamCityCaller = A.Fake<ITeamCityCaller>();
            var buildConfigs = new Investigations(teamCityCaller);

            // Act
            buildConfigs.InvestigationsByBuildConfiguration(BuildTypeLocator.WithName("buildTypeName"));

            // Assert
            A.CallTo(
                () =>
                    teamCityCaller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=buildType:({0})",
                        A<BuildTypeLocator>.That.Matches(l => l.Name == "buildTypeName"))).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void InvestigationsByUser_Name_GetFormatCalled()
        {
            // Arrange
            var teamCityCaller = A.Fake<ITeamCityCaller>();
            var buildConfigs = new Investigations(teamCityCaller);

            // Act
            buildConfigs.InvestinationsByUser(UserLocator.WithUserName("chuck"));

            // Assert
            A.CallTo(
                () =>
                    teamCityCaller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=assignee:({0})",
                        A<UserLocator>.That.Matches(l => l.UserName == "chuck"))).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}