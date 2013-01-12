using System;
using System.Collections.Generic;
using NUnit.Framework;
using GenericsExample;

namespace GenericsExampleTests
{
	[TestFixture()]
	public class MeanCalculatorTests
	{
		[Test()]
		[ExpectedException( typeof( ArgumentNullException ) )] 
		public void ThrowsArgumentNullExceptionWhenNullIsPassedIn ()
		{
			MeanCalculator.Calculate<int> (null);
		}

		[Test()]
		[ExpectedException( typeof( ArgumentException ) )] 
		public void ThrowsArgumentExceptionWhenEmptyListIsPassedIn ()
		{
			MeanCalculator.Calculate<int> (new List<int> ());
		}
		
		[Test()]
		[ExpectedException( typeof( ArgumentException ) )] 
		public void ThrowsArgumentExceptionWhenListOfNonNumbersIsPassedInt ()
		{
			MeanCalculator.Calculate<char> (new List<char> (){'a', 'b'});
		}

		[Test()]
		public void CanCalculateMeanOfListInts ()
		{
			Assert.AreEqual (5.5, MeanCalculator.Calculate<int> (new List<int> (){1, 2, 3, 4, 5, 6, 7, 8, 9, 10}));
		}
		
		[Test()]
		public void CanCalculateMeanOfListDecimas ()
		{
			var calc = MeanCalculator.Calculate<double> 
				(new List<double> (){1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.9, 9.9});
			
			Assert.AreEqual (5.51, Math.Round (calc, 2));
		}
	}
}

