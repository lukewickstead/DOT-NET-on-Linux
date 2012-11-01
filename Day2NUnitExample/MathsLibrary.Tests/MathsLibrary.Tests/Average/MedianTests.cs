using System;
using System.Collections.Generic;
using MathsLibrary.Average;
using NUnit.Framework;

namespace MathsLibrary.Tests
{
	[TestFixture()]
	public class MedianTests
	{
		[Test()]
		public void CanCalculateMedianWithOddNumber()
		{
			
			var data = new List<decimal>{ 1.1m, 2.2m, 3.3m, 4.4m, 5.5m };

			var medianVale = Median.Calculate(data);

			Assert.AreEqual(medianVale, 3.3);
		}

		[Test()]
		public void CanCalculateMedianWithEvenNumber()
		{
			
			var data = new List<decimal>{ 1.1m, 2.2m, 3.3m, 4.4m };

			var medianVale = Median.Calculate(data);

			Assert.AreEqual(medianVale, 2.75);
		}

		[Test()]
		public void WillThrowArgumentNullExceptionWhenNull()
		{
			Assert.Throws<ArgumentNullException>(() => Median.Calculate(null));	
		}

		[Test()]
		public void WillThrowArgumentExceptionWhenEmptyCollection()
		{
			Assert.Throws<ArgumentException>(() => Median.Calculate(new List<decimal>()));		
		}	
	}
}

