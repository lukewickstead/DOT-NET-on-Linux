using NUnit.Framework;
using System;
using System.Linq;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class LinqToDataSetTests
	{
		LinqToDataSet sut = new LinqToDataSet ();

		[Test ()]
		public void TestSelectAll ()
		{
			var result = sut.SelectAll ();

			Assert.AreEqual (5, result.Count);
		}

		[Test ()]
		public void TestSelectBob ()
		{
			var result = sut.SelectBob ();

			Assert.AreEqual (1, result.Count);
			Assert.AreEqual ("Bob", result.FirstOrDefault () ["Name"]);
		}

		[Test ()]
		public void TestSelectAllOrderByAgeDescending ()
		{
			var result = sut.SelectAllOrderByAgeDescending ();

			Assert.AreEqual (5, result.Count);
			Assert.AreEqual (34, result.FirstOrDefault () ["Age"]);
			Assert.AreEqual (30, result.LastOrDefault () ["Age"]);
		}

		[Test ()]
		public void TestGetTotalAgeViaAnonymous ()
		{
			var result = sut.GetTotalAgeViaAnonymous ();

			Assert.AreEqual (160, result);
		}
	}
}