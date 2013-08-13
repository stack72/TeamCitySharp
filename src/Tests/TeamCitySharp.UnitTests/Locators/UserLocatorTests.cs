using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.UnitTests
{

    public class UserLocatorTests
    {

        [TestFixture]
        public class ToStringMethod
        {

            [Test]
            public void ReturnsWithNullId()
            {
                var locator = UserLocator.WithId(null);
                Assert.AreEqual("username:", locator.ToString());
            }

            [Test]
            public void ReturnsWithEmptyId()
            {
                var locator = UserLocator.WithId(null);
                Assert.AreEqual("username:", locator.ToString());
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
                var locator = UserLocator.WithUserName(null);
                Assert.AreEqual("username:", locator.ToString());
            }

            [Test]
            public void ReturnsWithEmptyName()
            {
                var locator = UserLocator.WithUserName(string.Empty);
                Assert.AreEqual("username:", locator.ToString());
            }

            [Test]
            public void ReturnsWithName()
            {
                var locator = UserLocator.WithUserName("USERNAME");
                Assert.AreEqual("username:USERNAME", locator.ToString());
            }
            
        }

    }

}
