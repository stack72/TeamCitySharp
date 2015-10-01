using FakeItEasy;
using NUnit.Framework;
using TeamCitySharp.ActionTypes;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.Tests.ActionTypes
{
    [TestFixture]
    public class BuildsTests
    {
        [Test]
        public void ByBuildLocator_Include_GetFormatCalled()
        {
            // Arrange
            var teamCityCaller = A.Fake<ITeamCityCaller>(s => s.Strict());
            A.CallTo(() => teamCityCaller.GetFormat<BuildWrapper>(A<string>._, A<object[]>._))
                .Returns(new BuildWrapper {Count = "1"});

            var builds = new Builds(teamCityCaller);

            // Act
            var byBuildLocator = builds.ByBuildLocator(BuildLocator.WithId(123456),
                x => x.IncludeStartDate()
                    .IncludeFinishDate()
                    .IncludeStatusText());

            // Assert
            A.CallTo(
                () => teamCityCaller.GetFormat<BuildWrapper>("/app/rest/builds?locator={0}&fields=count,build({1})",
                    A<object[]>.That.IsSameSequenceAs(
                        new[]
                        {
                            "id:123456",
                            "buildTypeId,href,id,number,state,status,webUrl,startDate,finishDate,statusText"
                        }))).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}