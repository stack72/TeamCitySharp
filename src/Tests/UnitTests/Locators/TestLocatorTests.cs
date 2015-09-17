using FluentAssertions;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.Tests.Locators
{
    [TestFixture]
    public class TestLocatorTests
    {
        [Test]
        public void WithId_Id_LocatorFormatted()
        {
            // Arrange
            var testLocator = TestLocator.WithId("123");
            // Act
            var locatorAsString = testLocator.ToString();

            // Assert
            locatorAsString.Should().Be("id:123");
        }

        [Test]
        public void WithName_Name_LocatorFormatted()
        {
            // Arrange
            var testLocator = TestLocator.WithName("test name");
            
            // Act
            var locatorAsString = testLocator.ToString();

            // Assert
            locatorAsString.Should().Be("name:test name");
        }
    }
}

