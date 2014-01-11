using System;
using System.Data.Common;
using System.Configuration;

namespace ADO.Connections
{
	public class ConnectionStringBuilderExample
	{
		public static bool Example ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var dbFactory = DbProviderFactories.GetFactory (providerName);   

			var builder = dbFactory.CreateConnectionStringBuilder ();
			builder.ConnectionString = connectionString;
			builder ["ConnectionTimeout"] = 60;

			using (var connection = dbFactory.CreateConnection ()) {     
				connection.ConnectionString = builder.ConnectionString;     
				connection.Open ();

				return connection.State == System.Data.ConnectionState.Open;
			}
		}
	}
}