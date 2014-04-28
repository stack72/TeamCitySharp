using System;
using System.Collections.Generic;

using NUnit.Framework;

using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    [TestFixture]
    public class when_interations_to_get_build_steps
    {
        private ITeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("teamcity.codebetter.com");
            _client.Connect("teamcitysharpuser", "qwerty");
        }


        [Test]
        public void it_accepts_posted_build_step()
        {
            var client = new TeamCityClient("localhost:81");
            client.Connect("admin", "qwerty");

            client.BuildSteps.Create("bt5", new BuildStep
            {
                Name = "Build",
                Type = "VS.Solution",
                Properties = new Properties
                {
                    Property = new List<Property>
                    {
                        new Property
                        {
                            Name = "msbuild.prop.Configuration",
                            Value = "Debug"
                        },
                    }
                }
            });
        }


        [Test]
        public void it_returns_all_build_steps()
        {
            var buildSteps = _client.BuildSteps.ByConfigurationId("bt437");

            Assert.That(buildSteps, Has.Count.GreaterThan(0), "No build steps were found.");
        }
    }
}