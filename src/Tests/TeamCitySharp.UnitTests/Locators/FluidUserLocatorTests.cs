using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.UnitTests
{

    public class FluidUserLocatorTests
    {

        [TestFixture]
        public class ToStringMethod
        {

            [Test]
            public void ReturnsWithNullId()
            {
                var locator = FluidUserLocator.WithId(null);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithEmptyId()
            {
                var locator = FluidUserLocator.WithId(null);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithId()
            {
                var locator = FluidUserLocator.WithId("9999");
                Assert.AreEqual("id:9999", locator.ToString());
            }

            [Test]
            public void ReturnsWithNullName()
            {
                var locator = FluidUserLocator.WithUserName(null);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithEmptyName()
            {
                var locator = FluidUserLocator.WithUserName(string.Empty);
                Assert.AreEqual(string.Empty, locator.ToString());
            }

            [Test]
            public void ReturnsWithName()
            {
                var locator = FluidUserLocator.WithUserName("USERNAME");
                Assert.AreEqual("username:USERNAME", locator.ToString());
            }

        }

    }

}
