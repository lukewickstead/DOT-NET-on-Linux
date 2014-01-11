//-----------------------------------------------------------------------
// <copyright file="MeanTests.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace MathsLibrary.Tests
{
    using System;
    using System.Collections.Generic;
    using MathsLibrary.Average;
    using NUnit.Framework;

    /// <summary>
    /// Mean tests.
    /// </summary>
    [TestFixture]
    public class MeanTests
    {
        /// <summary>
        /// Mean test
        /// </summary>
        [Test]
        public void CanCalculateMean()
        {            
            var data = new List<decimal> { 1.1m, 2.2m, 3.3m, 4.4m, 5.5m };

            var modeValue = Mean.Calculate(data);

            Assert.AreEqual(modeValue, 3.3);
        }

        /// <summary>
        /// Checks error thrown when null passed in
        /// </summary>
        [Test]
        public void WillThrowArgumentNullExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => Mean.Calculate(null));   
        }

        /// <summary>
        /// Checks error thrown when an empty collection is passed in.
        /// </summary>
        [Test]
        public void WillThrowArgumentExceptionWhenEmptyCollection()
        {
            Assert.Throws<ArgumentException>(() => Mean.Calculate(new List<decimal>()));        
        }   
    }
}