using NUnit.Framework;
using System;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class StopwatchExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var result = StopwatchExample.Example ();

			Assert.Greater (result.Milliseconds, 0);
		}
	}
}

