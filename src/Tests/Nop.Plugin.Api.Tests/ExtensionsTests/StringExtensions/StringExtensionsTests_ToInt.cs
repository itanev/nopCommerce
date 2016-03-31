﻿using Nop.Plugin.Api.Extensions;
using NUnit.Framework;

namespace Nop.Plugin.Api.Tests.ExtensionsTests.StringExtensions
{
    [TestFixture]
    public class StringExtensionsTests_ToInt
    {
        private IStringExtensions _stringExtensions;

        [SetUp]
        public void SetUp()
        {
            _stringExtensions = new Extensions.StringExtensions();
        }

        [Test]
        [TestCase("3ed")]
        [TestCase("sd4")]
        [TestCase("675435345345345345345345343456546")]
        [TestCase("-675435345345345345345345343456546")]
        [TestCase("$%%^%^$#^&&%#)__(^&")]
        [TestCase("2015-02-12")]
        [TestCase("12:45")]
        public void WhenInvalidIntPassed_ShouldReturnZero(string invalidInt)
        {
            //Arange

            //Act
            int result = _stringExtensions.ToInt(invalidInt);

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void WhenNullOrEmptyStringPassed_ShouldReturnZero(string nullOrEmpty)
        {
            //Arange

            //Act
            int result = _stringExtensions.ToInt(nullOrEmpty);

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        [TestCase("3")]
        [TestCase("234234")]
        [TestCase("0")]
        [TestCase("-44")]
        [TestCase("000000005")]
        public void WhenValidIntPassed_ShouldReturnThatInt(string validInt)
        {
            //Arange
            int valid = int.Parse(validInt);

            //Act
            int result = _stringExtensions.ToInt(validInt);

            //Assert
            Assert.AreEqual(valid, result);
        }
    }
}