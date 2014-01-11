using NUnit.Framework;
using System;

namespace ADO.ConnectedLayer.Tests
{
	[TestFixture ()]
	public class DataReaderMultiSelectExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var count = DataReaderMultiSelectExample.Example ();

			Assert.AreEqual (2, count);
		}
	}
}