using EasyHttp.Http;
using FakeItEasy;
using NUnit.Framework;
using TeamCitySharp.ActionTypes;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

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
        
        [Test]
        public void Update_Name_PutCalled()
        {
            // Arrange
            var teamCityCaller = A.Fake<ITeamCityCaller>();
            var buildConfigs = new BuildConfigs(teamCityCaller);

            // Act
            buildConfigs.UpdateName(BuildTypeLocator.WithId("bt2"), "SOME NEW NAME");

            // Assert
            A.CallTo(() => teamCityCaller.PutFormat("SOME NEW NAME", HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/name", A<object[]>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}

