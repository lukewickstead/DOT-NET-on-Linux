using NUnit.Framework;
using System;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class DataViewExampleTests
	{
		[Test ()]
		public void TestExampleEquals ()
		{
			var sut = new DataViewExample ();
			sut.ExampleEquals ();

			Assert.AreEqual (1, sut.DV.Count);
		}


		[Test ()]
		public void TestExampleGreaterThan ()
		{
			var sut = new DataViewExample ();
			sut.ExampleGreaterThan ();

			Assert.AreEqual (sut.DT.Rows.Count -1, sut.DV.Count);
		}
	}
}

