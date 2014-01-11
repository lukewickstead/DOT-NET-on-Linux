using System;
using System.Data;

namespace ADO.DisconnectedLayer
{
	public class CreateSchemaExample
	{
		public DataSet DS { get; private set; }

		public CreateSchemaExample ()
		{
			CreateDataSet ();  

			CreateDataTable ("TheParent");
			CreateDataTable ("TheChild");				 
			CreateColumns ("TheParent", false);
			CreateColumns ("TheChild", true);

			CreationRelation ();   
			CreateFK ();
			CreateConstraint ();

			for (var x = 0; x <= 10; x++) {
				AddData (x);
			}
		}

		private void CreateDataSet ()
		{
			DS = new DataSet ("MyDataSet");
			DS.ExtendedProperties ["Create"] = DateTime.Now;
			DS.EnforceConstraints = true;
		}

		private void CreateDataTable (string aTable)
		{
			DS.Tables.Add (new DataTable (aTable));		
		}

		private void CreateColumns (string tableName, bool isChild)
		{
			var dataTable = DS.Tables [tableName];

			var idColumn = new DataColumn ("Id", typeof(int)) {
				Caption = "My Table ID",
				ReadOnly = true,
				AllowDBNull = false,
				Unique = true,
				AutoIncrement = true,
				AutoIncrementSeed = 0,
				AutoIncrementStep = 1,
			};

			dataTable.Columns.Add (idColumn);
			dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns [0] };

			var valColumn = new DataColumn ("Value", typeof(string)) {
				Caption = "My Table Value",
				AllowDBNull = false
			};

			dataTable.Columns.Add (valColumn);

			if (isChild) {

				var parentFKColumn = new DataColumn ("ParentId", typeof(int)) {
					Caption = "ParentId",
					ReadOnly = true,
					AllowDBNull = false
				};

				dataTable.Columns.Add (parentFKColumn);

				parentFKColumn = new DataColumn ("ParentIdFK", typeof(int)) {
					Caption = "ParentIdFK",
					ReadOnly = true,
					AllowDBNull = false
				};

				dataTable.Columns.Add (parentFKColumn);


				var valTwoColumn = new DataColumn ("ValueTwo", typeof(string)) {
					Caption = "My Table Value",
					AllowDBNull = false
				};

				dataTable.Columns.Add (valTwoColumn);
			}
		}

		private void CreationRelation ()
		{
			var parent = DS.Tables ["TheParent"].Columns ["Id"];
			var child = DS.Tables ["TheChild"].Columns ["ParentId"];

			var dr = new DataRelation ("ParentChild", parent, child);
			DS.Relations.Add (dr);
		}

		private void CreateFK ()
		{
			var parent = DS.Tables ["TheParent"].Columns ["Id"];
			var child = DS.Tables ["TheChild"].Columns ["ParentIdFK"];

			var fk = new ForeignKeyConstraint ("FK", parent, child);
			fk.DeleteRule = Rule.SetNull;
			fk.UpdateRule = Rule.Cascade;
			fk.AcceptRejectRule = AcceptRejectRule.None;

			DS.Tables ["TheChild"].Constraints.Add (fk);
		}

		private void CreateConstraint ()
		{
			var dataTable = DS.Tables ["TheChild"];

			var uniqueConstraint = new UniqueConstraint (new DataColumn[] {
				dataTable.Columns ["ValueTwo"],
				dataTable.Columns ["Value"]
			});

			DS.Tables ["TheChild"].Constraints.Add (uniqueConstraint);
		}

		private void AddData (int x)
		{
			var childTable = DS.Tables ["TheChild"];
			var parentTable = DS.Tables ["TheParent"];

			var parentRow = parentTable.NewRow ();
			var childRow = childTable.NewRow ();

			parentRow ["Value"] = "ParentValue" + x.ToString ();
			parentTable.Rows.Add (parentRow);

			var pkId = (int)parentRow ["Id"];

			childRow ["Value"] = "ChildValueOne" + x.ToString ();
			childRow ["ValueTwo"] = "ChildValueTwo" + x.ToString ();
			childRow ["ParentId"] = pkId;
			childRow ["ParentIdFK"] = pkId;
					
			childTable.Rows.Add (childRow);
		}
	}
}