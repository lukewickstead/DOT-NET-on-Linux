using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.DisconnectedLayer
{
	public class CallingAStoredProcesureExample
	{
		public static DataSet Example ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var dbFactory = DbProviderFactories.GetFactory (connectionDetails.ProviderName);   

			// Create and configure a connection
			using (var connection = dbFactory.CreateConnection ()) {
				connection.ConnectionString = connectionDetails.ConnectionString;

				// Create and configure a DbCommand
				var command = dbFactory.CreateCommand ();
				command.Connection = connection;
				command.CommandText = "spGetFoo";
				command.CommandType = CommandType.StoredProcedure;     

				// Create and configure a DbDataAdapter
				var adapter = dbFactory.CreateDataAdapter ();
				adapter.SelectCommand = command;

				// Fill A DataTable
				var dataSet = new DataSet ();
				adapter.Fill (dataSet);

				return dataSet;
			}
		}
	}
}