//-----------------------------------------------------------------------
// <copyright file="MedianTests.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace MathsLibrary.Tests
{
    using System;
    using System.Collections.Generic;
    using MathsLibrary.Average;
    using NUnit.Framework;

    /// <summary>
    /// Median tests.
    /// </summary>
    [TestFixture]
    public class MedianTests
    {
        /// <summary>
        /// Determines whether this instance can calculate median with odd number.
        /// </summary>
        [Test]
        public void CanCalculateMedianWithOddNumber()
        {            
            var data = new List<decimal> { 1.1m, 2.2m, 3.3m, 4.4m, 5.5m };

            var medianVale = Median.Calculate(data);

            Assert.AreEqual(medianVale, 3.3);
        }

        /// <summary>
        /// Determines whether this instance can calculate median with even number.
        /// </summary>
        [Test]
        public void CanCalculateMedianWithEvenNumber()
        {            
            var data = new List<decimal> { 1.1m, 2.2m, 3.3m, 4.4m };

            var medianVale = Median.Calculate(data);

            Assert.AreEqual(medianVale, 2.75);
        }

        /// <summary>
        /// Wills the throw argument null exception when null.
        /// </summary>
        [Test]
        public void WillThrowArgumentNullExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => Median.Calculate(null)); 
        }

        /// <summary>
        /// Wills the throw argument exception when empty collection.
        /// </summary>
        [Test]
        public void WillThrowArgumentExceptionWhenEmptyCollection()
        {
            Assert.Throws<ArgumentException>(() => Median.Calculate(new List<decimal>()));      
        }   
    }
}