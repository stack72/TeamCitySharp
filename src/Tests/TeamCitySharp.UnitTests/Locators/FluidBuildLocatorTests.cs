using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.UnitTests
{

    public class FluidBuildLocatorTests
    {

        [TestFixture]
        public class ToStringMethod
        {

            [Test]
            public void ReturnsWhenEmpty()
            {
                var locator = new FluidBuildLocator();
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithId()
            {
                var locator = FluidBuildLocator.WithId(9999);
                Assert.AreEqual("id:9999", locator.ToString());
            }

            [Test]
            public void ReturnsWithAgentName()
            {
                var locator = new FluidBuildLocator().WithAgentName("AGENTNAME");
                Assert.AreEqual("agentName:AGENTNAME", locator.ToString());
            }

            [Test]
            public void ReturnsWithStatusERROR()
            {
                var locator = new FluidBuildLocator().WithStatus(BuildStatus.ERROR);
                Assert.AreEqual("status:ERROR", locator.ToString());
            }

            [Test]
            public void ReturnsWithStatusFAILURE()
            {
                var locator = new FluidBuildLocator().WithStatus(BuildStatus.FAILURE);
                Assert.AreEqual("status:FAILURE", locator.ToString());
            }

            [Test]
            public void ReturnsWithStatusSUCCESS()
            {
                var locator = new FluidBuildLocator().WithStatus(BuildStatus.SUCCESS);
                Assert.AreEqual("status:SUCCESS", locator.ToString());
            }

            [Test]
            public void ReturnsWithPersonalTrue()
            {
                var locator = new FluidBuildLocator().WithPersonal(true);
                Assert.AreEqual("personal:True", locator.ToString());
            }

            [Test]
            public void ReturnsWithCancelledTrue()
            {
                var locator = new FluidBuildLocator().WithCancelled(true);
                Assert.AreEqual("canceled:True", locator.ToString());
            }

            [Test]
            public void ReturnsWithRunningTrue()
            {
                var locator = new FluidBuildLocator().WithRunning(true);
                Assert.AreEqual("running:True", locator.ToString());
            }

            [Test]
            public void ReturnsWithPinnedTrue()
            {
                var locator = new FluidBuildLocator().WithPinned(true);
                Assert.AreEqual("pinned:True", locator.ToString());
            }

            [Test]
            public void ReturnsWithMaxResults()
            {
                var locator = new FluidBuildLocator().WithMaxResults(9999);
                Assert.AreEqual("count:9999", locator.ToString());
            }

            [Test]
            public void ReturnsWithStartIndex()
            {
                var locator = new FluidBuildLocator().WithStartIndex(9999);
                Assert.AreEqual("start:9999", locator.ToString());
            }

            [Test]
            public void ReturnsWithNullUser()
            {
                var locator = new FluidBuildLocator().WithUser(null);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithUserId()
            {
                var locator = new FluidBuildLocator().WithUser(FluidUserLocator.WithId("9999"));
                Assert.AreEqual("user:(id:9999)", locator.ToString());
            }

            [Test]
            public void ReturnsWithUserName()
            {
                var locator = new FluidBuildLocator().WithUser(FluidUserLocator.WithUserName("USERNAME"));
                Assert.AreEqual("user:(username:USERNAME)", locator.ToString());
            }

            [Test]
            public void ReturnsWithTags()
            {
                var locator = new FluidBuildLocator().WithTags(new string[] { "tag1", "tag2" });
                Assert.AreEqual("tags:(tag1,tag2)", locator.ToString());
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
                var locator = new FluidBuildLocator().WithBranch(
                                                            FluidBranchLocator.WithDimensions(
                                                                    "BRANCHNAME",
                                                                    BranchLocatorFlag.Any,
                                                                    BranchLocatorFlag.Any,
                                                                    BranchLocatorFlag.Any));
                Assert.AreEqual("branch:(name:BRANCHNAME,default:any,unspecified:any,branched:any)", locator.ToString());
            }

            [Test]
            public void ReturnsWithSinceBuild()
            {
                var locator = new FluidBuildLocator().WithSinceBuild(FluidBuildLocator.WithId(9999));
                Assert.AreEqual("sinceBuild:(id:9999)", locator.ToString());
            }

            [Test]
            public void ReturnsWithIdAndBranch()
            {
                var locator = FluidBuildLocator.WithId(9999)
                    .WithBranch(FluidBranchLocator.WithDimensions(@default: BranchLocatorFlag.Any));
                Assert.AreEqual("id:9999,branch:(default:any)", locator.ToString());
            }

        }

    }

}
