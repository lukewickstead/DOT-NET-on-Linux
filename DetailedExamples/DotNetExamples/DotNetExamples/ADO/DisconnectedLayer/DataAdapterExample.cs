using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.DisconnectedLayer.Tests
{
	public class DataAdapterExample
	{
		public DataSet DS = new DataSet ();
		private IDbDataAdapter Adapter;

		public DataAdapterExample ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var dbFactory = DbProviderFactories.GetFactory (connectionDetails.ProviderName);   

			Adapter = dbFactory.CreateDataAdapter ();

			// Create and configure a connection
			using (var connection = dbFactory.CreateConnection ()) {
				connection.ConnectionString = connectionDetails.ConnectionString;

				// Create Select Command
				DbCommand selCmd = dbFactory.CreateCommand ();
				selCmd.CommandText = "SELECT idMyTable,FieldA FROM MyTable";
				selCmd.Connection = connection;

				Adapter.SelectCommand = selCmd;

				// Parameters
				var fieldAParam = dbFactory.CreateParameter ();
				fieldAParam.DbType = DbType.String;
				fieldAParam.ParameterName = "@FieldA";
				fieldAParam.SourceColumn = "FieldA";
				fieldAParam.DbType = DbType.String;
			                                  
				var idParam = dbFactory.CreateParameter ();
				idParam.DbType = DbType.Int32;
				idParam.ParameterName = "@idMyTable";
				idParam.SourceColumn = "idMyTable";
				idParam.DbType = DbType.Int32;

				// Configure Insert Command     
				var insCmd = dbFactory.CreateCommand ();

				insCmd.CommandText = "INSERT INTO MyTable (FieldA) VALUES (@FieldA)";

				insCmd.Parameters.Add (fieldAParam);
				insCmd.Connection = connection;
				insCmd.CommandType = CommandType.Text;
				Adapter.InsertCommand = insCmd;

				// Delete Command 
				var delCmd = dbFactory.CreateCommand ();

				delCmd.CommandText = "DELETE FROM MyTable WHERE idMyTable = @idMyTable"; 
				delCmd.Parameters.Add (idParam);
				delCmd.Connection = connection;
				delCmd.CommandType = CommandType.Text;
				Adapter.DeleteCommand = delCmd;

				// Configure Update Command.
				var upCmd = dbFactory.CreateCommand ();

				upCmd.CommandText = "UPDATE MyTable SET FieldA = @FieldA WHERE idMyTable = @idMyTable";
				upCmd.Parameters.Add (idParam);
				upCmd.Parameters.Add (fieldAParam);
				upCmd.Connection = connection;
				upCmd.CommandType = CommandType.Text;
				Adapter.UpdateCommand = upCmd;
			}

			Adapter.Fill (DS);
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