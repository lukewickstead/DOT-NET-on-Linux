using System;
using System.Data.Common;
using System.Configuration;

namespace ADO.Connections
{
	public class DbProviderFactoriesExample
	{
		public static bool Example ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			DbProviderFactory dbFactory = DbProviderFactories.GetFactory (providerName);   

			using (DbConnection connection = dbFactory.CreateConnection ()) {     
				connection.ConnectionString = connectionString;     
				connection.Open ();
				return connection.State == System.Data.ConnectionState.Open;
			}
		}
	}
}