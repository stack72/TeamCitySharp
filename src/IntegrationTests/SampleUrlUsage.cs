using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.IntegrationTests
{
    public class SampleUrlUsage
    {
        [Test]
        public void it_should_have_a_null_status_text_on_the_build_object_when_using_build_locator()
        {
            var client = new TeamCityClient("localhost:81");
            client.Connect("admin", "qwerty");

            var build = client.CallByUrl<Build>("/app/rest/builds?locator=buildType:(id:bt5),count:1");

            Assert.That(build.GetType() == typeof(Build));
            Assert.IsNull(build.StatusText);
        }

        [Test]
        public void it_should_have_status_text_on_the_build_object_when_using_build_locator()
        {
            var client = new TeamCityClient("localhost:81");
            client.Connect("admin", "qwerty");

            var build = client.CallByUrl<Build>("/app/rest/buildTypes/id:bt5/builds/id:32");

            Assert.That(build.GetType() == typeof(Build));
            Assert.IsNotNullOrEmpty(build.StatusText);
        }

    }
}
