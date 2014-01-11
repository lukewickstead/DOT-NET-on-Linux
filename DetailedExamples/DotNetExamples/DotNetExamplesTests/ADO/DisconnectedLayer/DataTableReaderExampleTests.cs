using NUnit.Framework;
using System;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class DataTableReaderExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new DataTableReaderExample ();
			Assert.IsTrue (sut.Example ());
		}
	}
}