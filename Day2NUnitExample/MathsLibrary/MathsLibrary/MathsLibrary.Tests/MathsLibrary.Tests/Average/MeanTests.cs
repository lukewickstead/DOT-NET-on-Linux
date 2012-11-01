using System;
using System.Collections.Generic;
using MathsLibrary.Average;
using NUnit.Framework;

namespace MathsLibrary.Tests
{
	[TestFixture()]
	public class MeanTests
	{
		[Test()]
		public void CanCalculateMean()
		{
			
			var data = new List<decimal>{ 1.1m, 2.2m, 3.3m, 4.4m, 5.5m };

			var modeValue = Mean.Calculate(data);

			Assert.AreEqual(modeValue, 3.3);
		}


		[Test()]
		public void WillThrowArgumentNullExceptionWhenNull()
		{
			Assert.Throws<ArgumentNullException>(() => Mean.Calculate(null));	
		}

		[Test()]
		public void WillThrowArgumentExceptionWhenEmptyCollection()
		{
			Assert.Throws<ArgumentException>(() => Mean.Calculate(new List<decimal>()));		
		}	
	}
}

