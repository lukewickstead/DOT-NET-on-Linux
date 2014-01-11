using NUnit.Framework;
using System;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class DebugExampleTests
	{
		[Test ()]
		[ExpectedException]
		[Ignore("Mono has a bug where  Assert and Fail are not throwing exceptions")]
		public void TestCase ()
		{
			DebugExample.Run ();
		}
	}
}