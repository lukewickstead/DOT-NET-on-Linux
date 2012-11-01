using System;
using System.Collections.Generic;
using MathsLibrary.Average;
using NUnit.Framework;

namespace MathsLibrary.Tests
{
	[TestFixture()]
	public class ModeTests
	{
		[Test()]
		public void CanCalculateModeWithNoGrouping ()
		{
			var data = new List<decimal>{ 1.1m, 2.2m, 2.2m, 3.3m, 4.4m, 5.5m };

			var modeValue = Mode.Calculate (data);

			Assert.AreEqual (modeValue, 2.2);
		}

		[Test()]
		public void CanNotCalculateModewithGrouping()
		{
			var data = new List<decimal>{ 1.1m, 2.2m };

			Assert.Throws<NotImplementedException>(() => Mode.Calculate(data));	
		}

		[Test()]
		public void WillThrowArgumentNullExceptionWhenNull()
		{
			Assert.Throws<ArgumentNullException>(() => Mode.Calculate(null));	
		}

		[Test()]
		public void WillThrowArgumentExceptionWhenEmptyCollection()
		{
			Assert.Throws<ArgumentException>(() => Mode.Calculate(new List<decimal>()));		
		}	
	}
}

