using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.UnitTests
{

    public class FluidBuildTypeLocatorTests
    {

        [TestFixture]
        public class ToStringMethod
        {

            [Test]
            public void ReturnsWithNullId()
            {
                var locator = FluidBuildTypeLocator.WithId(null);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithEmptyId()
            {
                var locator = FluidBuildTypeLocator.WithId(string.Empty);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithId()
            {
                var locator = FluidBuildTypeLocator.WithId("bt9999");
                Assert.AreEqual("id:bt9999", locator.ToString());
            }

            [Test]
            public void ReturnsWithNullName()
            {
                var locator = FluidBuildTypeLocator.WithName(null);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithEmptyName()
            {
                var locator = FluidBuildTypeLocator.WithName(string.Empty);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithName()
            {
                var locator = FluidBuildTypeLocator.WithName("BUILDTYPENAME");
                Assert.AreEqual("name:BUILDTYPENAME", locator.ToString());
            }

        }

    }

}
