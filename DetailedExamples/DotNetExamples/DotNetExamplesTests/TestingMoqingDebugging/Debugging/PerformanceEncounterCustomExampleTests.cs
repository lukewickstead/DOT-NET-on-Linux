using NUnit.Framework;
using System;
using TestingMoqingDebugging.Debugging;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class PerformanceEncounterCustomExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new PerformanceEncounterCustomExample ();
			sut.WriteCounters ();

			var hit = 0L;
			var rate = 0L;

			sut.ReadCounters (out hit, out rate);

			Assert.GreaterOrEqual (hit, 5);
			Assert.GreaterOrEqual (rate, 0);
		}
	}
}