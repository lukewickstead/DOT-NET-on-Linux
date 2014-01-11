using NUnit.Framework;
using System;
using ADO.ConnectedLayer;

namespace ADO.ConnectedLayer.Tests
{
	[TestFixture ()]
	public class DataReaderExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var count = DataReaderExample.Example ();
			Assert.Greater (count, 0);
		}
	}
}