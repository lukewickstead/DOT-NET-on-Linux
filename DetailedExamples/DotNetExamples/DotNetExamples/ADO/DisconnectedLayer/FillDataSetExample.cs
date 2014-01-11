using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.DisconnectedLayer
{
	public class FillDataSetExample
	{
		private static string queryString = "select idAnotherTable, StringField, IntField, DecimalField from AnotherTable; select idMyTable, FieldA from MyTable;";

		public static DataSet Example ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var dbFactory = DbProviderFactories.GetFactory (connectionDetails.ProviderName);   

			// Create and configure a connection
			var connection = dbFactory.CreateConnection ();
			connection.ConnectionString = connectionDetails.ConnectionString;

			// Create and configure a DbCommand
			var command = dbFactory.CreateCommand ();
			command.CommandText = queryString;
			command.Connection = connection;

			// Create and configure a DbDataAdapter
			var adapter = dbFactory.CreateDataAdapter ();
			adapter.SelectCommand = command;

			// Rename table mappings
			adapter.TableMappings.Add ("Table", "AnotherTable");
			adapter.TableMappings.Add ("Table1", "MyTable");

			// Fill A DataTable
			var dataSet = new DataSet ("TheDataSet");
			adapter.Fill (dataSet);

			return dataSet;
		}
	}
}