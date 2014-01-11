using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.ConnectedLayer
{
	public class DataReaderMultiSelectExample
	{
		public static int Example ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var dbFactory = DbProviderFactories.GetFactory (providerName);

			using (var cn = dbFactory.CreateConnection ()) {     
				cn.ConnectionString = connectionString;     
				cn.Open (); 

				var cmd = cn.CreateCommand ();

				cmd.CommandText = "Select * From MyTable; Select * from AnotherTable";
				cmd.CommandType = CommandType.Text;
				cmd.Connection = cn;

				var count = 0;

				using (var dr = cmd.ExecuteReader ()) {
					do {
						count++;
						do {
						} while (dr.Read ());
					} while (dr.NextResult ());
				}

				return count;
			}	 
		}
	}
}