using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

// TODO: Test - Find out how to create xsd export from MySQL WorkBench
namespace ADO.DisconnectedLayer
{
	public class StronglyTypedDataSetExample
	{
		public static DataSet Example ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;
			var dbFactory = DbProviderFactories.GetFactory (providerName);   

			var adapter = dbFactory.CreateDataAdapter ();

			// Fill	
			var myDataSet = new MyDataSet ();
			var myTable = new MyDataSet.MyTableDataTable ();     

			adapter.Fill (myTable);     

			foreach (MyDataSet.MyTableRow myTableRow in myTable) {
				var id = myTableRow.Id;
				var name = myTableRow.Name;
				var isMale = myTableRow.IsMale;
			}

			// insert
			MyDataSet.MyTableRow newRow = myTable.NewMyTableRow ();          

			newRow.Name = "Bobby McFroggy";     
			newRow.Id = 1;     
			newRow.IsMale = true;     

			myTable.AddMyTableRow (newRow);     

			myTable.AddMyTableRow (2, "James Pond", true);	

			adapter.Update (myTable);   
		
			return myDataSet;
		}
	}
}