using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.UnitTests
{

    public class FluidBranchLocatorTests
    {

        [TestFixture]
        public class ToStringMethod
        {

            [Test]
            public void ReturnsWhenEmpty()
            {
                var locator = new FluidBranchLocator();
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithName()
            {
                var locator = new FluidBranchLocator().WithName("testbranch/name");
                Assert.AreEqual("name:testbranch/name", locator.ToString());
            }

            [Test]
            public void ReturnsWithDefaultTrue()
            {
                var locator = new FluidBranchLocator().WithDefault(BranchLocatorFlag.True);
                Assert.AreEqual("default:true", locator.ToString());
            }

            [Test]
            public void ReturnsWithDefaultFalse()
            {
                var locator = new FluidBranchLocator().WithDefault(BranchLocatorFlag.False);
                Assert.AreEqual("default:false", locator.ToString());
            }

            [Test]
            public void ReturnsWithDefaultAny()
            {
                var locator = new FluidBranchLocator().WithDefault(BranchLocatorFlag.Any);
                Assert.AreEqual("default:any", locator.ToString());
            }

            [Test]
            public void ReturnsWithUnspecifiedTrue()
            {
                var locator = new FluidBranchLocator().WithUnspecified(BranchLocatorFlag.True);
                Assert.AreEqual("unspecified:true", locator.ToString());
            }

            [Test]
            public void ReturnsWithUnspecifiedFalse()
            {
                var locator = new FluidBranchLocator().WithUnspecified(BranchLocatorFlag.False);
                Assert.AreEqual("unspecified:false", locator.ToString());
            }

            [Test]
            public void ReturnsWithUnspecifiedAny()
            {
                var locator = new FluidBranchLocator().WithUnspecified(BranchLocatorFlag.Any);
                Assert.AreEqual("unspecified:any", locator.ToString());
            }

            [Test]
            public void ReturnsWithBranchedTrue()
            {
                var locator = new FluidBranchLocator().WithBranched(BranchLocatorFlag.True);
                Assert.AreEqual("branched:true", locator.ToString());
            }

            [Test]
            public void ReturnsWithBranchedFalse()
            {
                var locator = new FluidBranchLocator().WithBranched(BranchLocatorFlag.False);
                Assert.AreEqual("branched:false", locator.ToString());
            }

            [Test]
            public void ReturnsWithBranchedAny()
            {
                var locator = new FluidBranchLocator().WithBranched(BranchLocatorFlag.Any);
                Assert.AreEqual("branched:any", locator.ToString());
            }

            [Test]
            public void ReturnsWithDimensionsEmpty()
            {
                var locator = FluidBranchLocator.WithDimensions();
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithDimensionsNull()
            {
                var locator = FluidBranchLocator.WithDimensions(null, null, null, null);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithDimensions()
            {
                var locator = FluidBranchLocator.WithDimensions("testbranch/name", BranchLocatorFlag.True, BranchLocatorFlag.True, BranchLocatorFlag.True);
                Assert.AreEqual("name:testbranch/name,default:true,unspecified:true,branched:true", locator.ToString());
            }

        }

    }

}
