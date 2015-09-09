using FakeItEasy;
using NUnit.Framework;
using TeamCitySharp.ActionTypes;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

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
            buildConfigs.InvestigationsById("123");

            // Assert
            A.CallTo(
                () =>
                    teamCityCaller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=test:(id:{0})",
                        "123")).MustHaveHappened(Repeated.Exactly.Once);

        }

        [Test]
        public void InvestigationByName_Name_GetFormatCalled()
        {
            // Arrange
            var teamCityCaller = A.Fake<ITeamCityCaller>();
            var buildConfigs = new Investigations(teamCityCaller);

            // Act
            buildConfigs.InvestigationsByName("test name");

            // Assert
            A.CallTo(
                () =>
                    teamCityCaller.GetFormat<InvestigationWrapper>("/app/rest/investigations?locator=test:(name:{0})",
                        "test name")).MustHaveHappened(Repeated.Exactly.Once);

        }
    }
}

