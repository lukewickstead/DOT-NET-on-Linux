using NUnit.Framework;
using System;
using ADO.ConnectedLayer;

namespace ADO.ConnectedLayer.Tests
{
	[TestFixture ()]
	public class CommandParametersExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var count = CommandParametersExample.Example ();

			Assert.AreEqual (1, count);
		}
	}
}