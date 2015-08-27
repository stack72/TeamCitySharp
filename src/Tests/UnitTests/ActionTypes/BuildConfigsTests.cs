using EasyHttp.Http;
using FakeItEasy;
using NUnit.Framework;
using TeamCitySharp.ActionTypes;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.Tests.ActionTypes
{
    [TestFixture]
    public class BuildConfigsTests
    {
        [Test]
        public void TriggerBuildConfiguration_OneProperty_PostFormatCalledWithProperBody()
        {
            // Arrange
            var teamCityCaller = A.Fake<ITeamCityCaller>();
            var buildConfigs = new BuildConfigs(teamCityCaller);

            // Act
            buildConfigs.TriggerBuildConfiguration("buildConfigId", new[]{ new Property { Name ="att1", Value = "val1"} });

            // Assert
            A.CallTo(() => teamCityCaller.PostFormat(@"<build>
<buildType id=""buildConfigId""/>
<properties>
<property name=""att1"" value=""val1""/>
</properties>
</build>
", HttpContentTypes.ApplicationXml, "/app/rest/buildQueue"))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}

