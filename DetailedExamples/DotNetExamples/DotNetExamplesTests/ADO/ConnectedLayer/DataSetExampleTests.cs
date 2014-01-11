using NUnit.Framework;
using System;
using ADO.ConnectedLayer;

namespace ADO.ConnectedLayer.Tests
{
	[TestFixture ()]
	public class DataSetExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var count = DataSetExample.Example ();

			Assert.Greater (count, 1);
		}
	}
}