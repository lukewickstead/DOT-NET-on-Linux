using NUnit.Framework;
using System;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class AccesingDataWithinADataSetExampleTests
	{
		AccesingDataWithinADataSetExample sut = new AccesingDataWithinADataSetExample ();

		[Test ()]
		public void TestAccesingDataSetExample ()
		{
			var name = string.Empty;
			var propertyCount = 0;

			sut.AccesingDataSetExample (out name, out propertyCount);

			Assert.AreEqual ("TheDataSet", name);
			Assert.AreEqual (1, propertyCount);
		}

		[Test ()]
		public void TestAccessingDataTable ()
		{
			var pkName = string.Empty;
			var tableCount = 0;

			sut.AccessingDataTable (out tableCount, out pkName);

			Assert.AreEqual ("AnotherTable", pkName);
			Assert.AreEqual (2, tableCount);
		}

		[Test ()]
		public void TestAccessingDataRow ()
		{
			var rowCount = 0;

			sut.AccessingDataRow (out rowCount);

			Assert.Greater (rowCount, 1);
		}

		[Test ()]
		public void TestAccessingDataColumn ()
		{
			var colCount = 0;

			var aColumn = sut.AccessingDataColumn (out colCount);

			Assert.AreEqual (4, colCount);

			Assert.AreEqual ("idAnotherTable", aColumn.ColumnName);
			Assert.AreEqual ("AnotherTable", aColumn.Table.TableName);
			Assert.AreEqual (0, aColumn.Ordinal);
			Assert.AreEqual (true, aColumn.AllowDBNull);
		}
	}
}
