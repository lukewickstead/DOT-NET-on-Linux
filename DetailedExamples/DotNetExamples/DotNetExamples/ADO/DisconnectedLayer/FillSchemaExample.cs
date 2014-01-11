using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace ADO.DisconnectedLayer
{
	public class FillSchemaExample
	{
		public static DataSet Example ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var queryString = "SELECT idMyTable, FieldA FROM MyTable";
			var dbFactory = DbProviderFactories.GetFactory (providerName);  

			var adapter = dbFactory.CreateDataAdapter ();
			var cmd = dbFactory.CreateCommand ();
			cmd.CommandText = queryString;
			cmd.CommandType = CommandType.Text;

			var aDataSet = new DataSet ();

			using (var con = dbFactory.CreateConnection ()) {
		
				con.ConnectionString = connectionString;
				cmd.Connection = con;
				adapter.SelectCommand = cmd;
				adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
				adapter.Fill (aDataSet);
			}

			return aDataSet;
		}
	}
}