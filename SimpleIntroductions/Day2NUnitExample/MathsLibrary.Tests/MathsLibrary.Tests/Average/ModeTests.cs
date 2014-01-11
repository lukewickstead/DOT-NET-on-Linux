//-----------------------------------------------------------------------
// <copyright file="ModeTests.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>

namespace MathsLibrary.Tests
{
    using System;
    using System.Collections.Generic;
    using MathsLibrary.Average;
    using NUnit.Framework;

    /// <summary>
    /// Mode tests.
    /// </summary>
    [TestFixture]
    public class ModeTests
    {
        /// <summary>
        /// Determines whether this instance can calculate mode with no grouping.
        /// </summary>
        [Test]
        public void CanCalculateModeWithNoGrouping()
        {
            var data = new List<decimal> { 1.1m, 2.2m, 2.2m, 3.3m, 4.4m, 5.5m };

            var modeValue = Mode.Calculate(data);

            Assert.AreEqual(modeValue, 2.2);
        }

        /// <summary>
        /// Determines whether this instance can not calculate modewith grouping.
        /// </summary>
        [Test]
        public void CanNotCalculateModewithGrouping()
        {
            var data = new List<decimal> { 1.1m, 2.2m };

            Assert.Throws<NotImplementedException>(() => Mode.Calculate(data)); 
        }

        /// <summary>
        /// Wills the throw argument null exception when null.
        /// </summary>
        [Test]
        public void WillThrowArgumentNullExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => Mode.Calculate(null));   
        }

        /// <summary>
        /// Wills the throw argument exception when empty collection.
        /// </summary>
        [Test]
        public void WillThrowArgumentExceptionWhenEmptyCollection()
        {
            Assert.Throws<ArgumentException>(() => Mode.Calculate(new List<decimal>()));        
        }   
    }
}