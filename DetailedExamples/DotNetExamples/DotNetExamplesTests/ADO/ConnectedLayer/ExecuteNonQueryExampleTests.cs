using NUnit.Framework;
using System;
using ADO.ConnectedLayer;

namespace ADO.ConnectedLayer.Tests
{
	[TestFixture ()]
	public class ExecuteNonQueryExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var count = ExecuteNonQueryExample.Example ();

			Assert.AreEqual (1, count);
		}
	}
}

