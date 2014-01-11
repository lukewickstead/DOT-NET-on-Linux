using NUnit.Framework;
using System;
using System.Linq;
using TestingMoqingDebugging.Debugging;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class PerformanceCounterMemoryExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var result = PerformanceCounterMemoryExample.Example ();

			Assert.AreEqual (1000, result.Count);
			Assert.IsTrue (result.All (x => x > 0)); 
		}
	}
}