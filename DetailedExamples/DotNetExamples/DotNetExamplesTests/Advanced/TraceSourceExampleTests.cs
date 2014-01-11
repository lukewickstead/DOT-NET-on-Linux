using NUnit.Framework;
using System;
using TestingMoqingDebugging.Debugging;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class TraceSourceExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new TraceSourceExample ();
			sut.Example ();
			var result = sut.ReadFile ();

			Assert.IsNotEmpty (result);
		}
	}
}

