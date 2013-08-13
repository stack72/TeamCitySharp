using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.UnitTests
{

    public class BuildLocatorTests
    {

        [TestFixture]
        public class ToStringMethod
        {

            [Test]
            public void ReturnsWhenEmpty()
            {
                var locator = new BuildLocator();
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithId()
            {
                var locator = BuildLocator.WithId(9999);
                Assert.AreEqual("id:9999", locator.ToString());
            }

            [Test]
            public void ReturnsWithAgentName()
            {
                var locator = BuildLocator.WithDimensions(agentName: "AGENTNAME");
                Assert.AreEqual("agentName:AGENTNAME", locator.ToString());
            }

            [Test]
            public void ReturnsWithStatusERROR()
            {
                var locator = BuildLocator.WithDimensions(status: BuildStatus.ERROR);
                Assert.AreEqual("status:ERROR", locator.ToString());
            }

            [Test]
            public void ReturnsWithStatusFAILURE()
            {
                var locator = BuildLocator.WithDimensions(status: BuildStatus.FAILURE);
                Assert.AreEqual("status:FAILURE", locator.ToString());
            }

            [Test]
            public void ReturnsWithStatusSUCCESS()
            {
                var locator = BuildLocator.WithDimensions(status: BuildStatus.SUCCESS);
                Assert.AreEqual("status:SUCCESS", locator.ToString());
            }

            [Test]
            public void ReturnsWithPersonalTrue()
            {
                var locator = BuildLocator.WithDimensions(personal: true);
                Assert.AreEqual("personal:True", locator.ToString());
            }

            [Test]
            public void ReturnsWithCancelledTrue()
            {
                var locator = BuildLocator.WithDimensions(canceled: true);
                Assert.AreEqual("canceled:True", locator.ToString());
            }

            [Test]
            public void ReturnsWithRunningTrue()
            {
                var locator = BuildLocator.WithDimensions(running: true);
                Assert.AreEqual("running:True", locator.ToString());
            }

            [Test]
            public void ReturnsWithPinnedTrue()
            {
                var locator = BuildLocator.WithDimensions(pinned: true);
                Assert.AreEqual("pinned:True", locator.ToString());
            }

            [Test]
            public void ReturnsWithMaxResults()
            {
                var locator = BuildLocator.WithDimensions(maxResults: 9999);
                Assert.AreEqual("count:9999", locator.ToString());
            }

            [Test]
            public void ReturnsWithStartIndex()
            {
                var locator = BuildLocator.WithDimensions(startIndex: 9999);
                Assert.AreEqual("start:9999", locator.ToString());
            }

            [Test]
            public void ReturnsWithTags()
            {
                var locator = new FluidBuildLocator().WithTags(new string[] { "tag1", "tag2" });
                Assert.AreEqual("tags:(tag1,tag2)", locator.ToString());
            }

            [Test]
            public void ReturnsWithNullUser()
            {
                var locator = BuildLocator.WithDimensions(user: null);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithUserId()
            {
                var locator = BuildLocator.WithDimensions(user: UserLocator.WithId("9999"));
                Assert.AreEqual("user:(id:9999)", locator.ToString());
            }

            [Test]
            public void ReturnsWithUserName()
            {
                var locator = BuildLocator.WithDimensions(user: UserLocator.WithUserName("USERNAME"));
                Assert.AreEqual("user:(username:USERNAME)", locator.ToString());
            }

            [Test]
            public void ReturnsWithNullBranch()
            {
                var locator = new FluidBuildLocator().WithUser(null);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithBranch()
            {
                var locator = BuildLocator.WithDimensions(branch: "BRANCHNAME");
                Assert.AreEqual("branch:(BRANCHNAME)", locator.ToString());
            }

            [Test]
            public void ReturnsWithSinceBuild()
            {
                var locator = BuildLocator.WithDimensions(sinceBuild: BuildLocator.WithId(9999));
                Assert.AreEqual("sinceBuild:(id:9999)", locator.ToString());
            }

        }

    }

}
