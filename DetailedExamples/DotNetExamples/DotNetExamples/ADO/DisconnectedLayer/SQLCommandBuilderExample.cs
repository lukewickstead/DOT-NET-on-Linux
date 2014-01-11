using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.DisconnectedLayer.Tests
{
	public class SQLCommandBuilderExample
	{
		public DataSet DS = new DataSet ();
		private IDbDataAdapter Adapter;

		public SQLCommandBuilderExample ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;
			var dbFactory = DbProviderFactories.GetFactory (providerName);   

			Adapter = dbFactory.CreateDataAdapter ();

			// Create and configure a connection
			using (var connection = dbFactory.CreateConnection ()) {

				connection.ConnectionString = connectionString;

				// Create Select Command
				var selCmd = dbFactory.CreateCommand ();
				selCmd.CommandText = "SELECT idMyTable, FieldA FROM MyTable";
				selCmd.Connection = connection;
				Adapter.SelectCommand = selCmd;

				// Create and configure DbCommandBuilder
				var builder = dbFactory.CreateCommandBuilder ();
				builder.DataAdapter = (DbDataAdapter)Adapter;

				// Create and fill a DataTable
				Adapter.Fill (DS);
			}
		}

		public bool Example ()
		{
			var dataTable = DS.Tables [0];

			// Delete
			dataTable.Rows [0].Delete ();

			// Update
			dataTable.Rows [1] ["FieldA"] = DateTime.Now.ToString ();

			// Insert
			var newRow = dataTable.NewRow ();
			newRow ["FieldA"] = DateTime.Now.ToString ();
			dataTable.Rows.Add (newRow);

			// Persist
			Adapter.Update (DS);

			return true;
		}
	}
}