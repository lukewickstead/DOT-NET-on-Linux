using NUnit.Framework;
using System;
using System.Linq;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class QueryingDataTableExampleTests
	{
		QueryingDataTableExample sut = new QueryingDataTableExample();

		[Test ()]
		public void TestSelectAllExample ()
		{
			var rows = sut.SelectAllExample ();

			Assert.AreEqual (sut.Table.Rows.Count, rows.Length);
		}

		[Test ()]
		public void TestSelectExample ()
		{
			var rows = sut.SelectExample ();

			var aValue = (string)sut.Table.Rows [0] ["StringField"];

			Assert.IsTrue (rows.All( x => (string)x["StringField"] == aValue));
		}

		[Test ()]
		public void TestSortSingleFieldExample ()
		{
			var rows = sut.SortSingleFieldExample ();

			Assert.LessOrEqual ((string)rows.FirstOrDefault()["StringField"], (string)rows.LastOrDefault()["StringField"]);
		}

		[Test ()]
		public void TestSortMultipleFieldExample ()
		{
			var rows = sut.SortMultipleFieldExample ();

			Assert.LessOrEqual ((string)rows.FirstOrDefault()["StringField"], (string)rows.LastOrDefault()["StringField"]);
			Assert.LessOrEqual ((int)rows.FirstOrDefault()["IntField"], (int)rows.LastOrDefault()["IntField"]);
		}

		[Test ()]
		public void TestSortDescendingExample ()
		{
			var rows = sut.SortDescendingExample ();

			Assert.GreaterOrEqual ((string)rows.FirstOrDefault()["StringField"], (string)rows.LastOrDefault()["StringField"]);
		}
	}
}