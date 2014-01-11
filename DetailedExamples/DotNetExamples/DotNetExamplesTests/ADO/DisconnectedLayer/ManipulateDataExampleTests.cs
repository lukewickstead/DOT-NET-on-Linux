using NUnit.Framework;
using System;
using System.Data;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class ManipulateDataExampleTests
	{
		private DataSet DS;

		public ManipulateDataExampleTests ()
		{
			/*DS = new DataSet ();
			var aDataTable = new DataTable ();

			aDataTable.Columns.Add (new DataColumn ("Field", typeof(string)));
			DS.Tables.Add (aDataTable);

			foreach (var x in new int[] { 1,2,3,4,5 }) {
				AddRow (x.ToString ());
			}
			*/

			DS = FillDataSetExample.Example ();

		}

		private void AddRow (string aValue)
		{
			var aDataTable = DS.Tables [0];
			var aRow = aDataTable.NewRow ();
			aRow ["Field"] = aValue;
			aDataTable.Rows.Add (aRow);
		}

		[Test ()]
		public void TestDataRowState ()
		{
			var aDataTable = DS.Tables [0];

			var row = aDataTable.NewRow (); 	// RowState is Detached
			Assert.AreEqual (DataRowState.Detached, row.RowState);

			aDataTable.Rows.Add (row);			// RowState is Added
			Assert.AreEqual (DataRowState.Added, row.RowState);

			row = aDataTable.Rows [0];
			row [0] = 11; 						// RowState is Modified   
			Assert.AreEqual (DataRowState.Modified, row.RowState);

			row.AcceptChanges ();   			// RowState is Unchanged
			Assert.AreEqual (DataRowState.Unchanged, row.RowState);

			row = aDataTable.Rows [0];
			row.Delete ();   					// RowState is Deleted
			Assert.AreEqual (DataRowState.Deleted, row.RowState);
		}

		[Test ()]
		public void TestDeletingExample ()
		{			
			var aDataTable = DS.Tables [1];
			var preCount = aDataTable.Rows.Count;

			aDataTable.Rows [0].Delete ();    

			var aDataRow = aDataTable.Rows [1];
			aDataRow.Delete ();

			aDataTable.AcceptChanges ();
			Assert.AreEqual (preCount - 2, aDataTable.Rows.Count);
		}

		[Test ()]
		public void TestUpdatingExample ()
		{
			var aDataTable = DS.Tables [1];
			aDataTable.Rows [0] ["idMyTable"] = 987654321;
			aDataTable.Rows [0] ["FieldA"] = "NewValue";

			var aDataRow = aDataTable.Rows [1];
			aDataRow ["idMyTable"] = 987654321;
			aDataRow ["FieldA"] = "NewValue";

			Assert.AreEqual ("NewValue", aDataTable.Rows [1] ["FieldA"]);		
		}

		[Test ()]
		public void TestInsertingExample ()
		{
			var aDataTable = DS.Tables [0];
			var preCount = aDataTable.Rows.Count;

			DataRow dataRow = aDataTable.NewRow ();   

			dataRow ["idAnotherTable"] = "1";
			dataRow ["StringField"] = "Value";

			aDataTable.Rows.Add (dataRow);
			Assert.AreEqual (preCount + 1, aDataTable.Rows.Count);
		}

		[Test ()]
		public void TestValidatingExample ()
		{
			var aDataTable = DS.Tables [1];

			DataRow dataRow = aDataTable.NewRow ();   
			dataRow ["FieldA"] = "AValue";
			aDataTable.Rows.Add (dataRow);

			dataRow.SetColumnError (0, "Invalid Data");
			dataRow.SetColumnError ("FieldA", "Invalid Data");

			Assert.IsTrue (DS.HasErrors);
			Assert.IsTrue (aDataTable.HasErrors);

			Assert.AreEqual (1, aDataTable.GetErrors ().Length);

			Assert.AreEqual (2, dataRow.GetColumnsInError ().Length);
			Assert.AreEqual ("Invalid Data", dataRow.GetColumnError (0));

			dataRow.ClearErrors ();

			Assert.IsFalse (DS.HasErrors);
			Assert.IsFalse (aDataTable.HasErrors);
			Assert.AreEqual (0, aDataTable.GetErrors ().Length);
		}

		[Test()]
		public void TestDatasetValidationPattern()
		{
			var sut = new DatasetValidationPattern ();

			Assert.AreEqual ("Ohhh nooo!!!", sut.Example ().Replace("\n", string.Empty));
		}
	}
}