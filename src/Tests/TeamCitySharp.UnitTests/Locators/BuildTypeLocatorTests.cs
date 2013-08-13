using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.UnitTests
{

    public class BuildTypeLocatorTests
    {

        [TestFixture]
        public class ToStringMethod
        {

            [Test]
            public void ReturnsWithNullId()
            {
                var locator = BuildTypeLocator.WithId(null);
                Assert.AreEqual("name:", locator.ToString());
            }

            [Test]
            public void ReturnsWithEmptyId()
            {
                var locator = BuildTypeLocator.WithId(string.Empty);
                Assert.AreEqual("name:", locator.ToString());
            }

            [Test]
            public void ReturnsWithId()
            {
                var locator = BuildTypeLocator.WithId("bt9999");
                Assert.AreEqual("id:bt9999", locator.ToString());
            }

            [Test]
            public void ReturnsWithNullName()
            {
                var locator = BuildTypeLocator.WithName(null);
                Assert.AreEqual("name:", locator.ToString());
            }

            [Test]
            public void ReturnsWithEmptyName()
            {
                var locator = BuildTypeLocator.WithName(string.Empty);
                Assert.AreEqual("name:", locator.ToString());
            }

            [Test]
            public void ReturnsWithName()
            {
                var locator = BuildTypeLocator.WithName("buildTypeName");
                Assert.AreEqual("name:buildTypeName", locator.ToString());
            }

        }

    }

}
