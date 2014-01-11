using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.ConnectedLayer
{
	public class ExecutingAStoredProcedureExample
	{
		public static long Example (out int outPutParam)
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
				cmd.CommandText = "spGetFooScalar";
				cmd.Connection = cn;

				cmd.CommandType = CommandType.StoredProcedure;     

				// Input param.				 
				var paramOne = cmd.CreateParameter ();    
				paramOne.ParameterName = "@inParam";     
				paramOne.DbType = DbType.Int32;     
				paramOne.Value = 1;     
				paramOne.Direction = ParameterDirection.Input;     
				cmd.Parameters.Add (paramOne);     

				// Output param.     
				var paramTwo = cmd.CreateParameter ();
				paramTwo.ParameterName = "@outParam";    
				paramTwo.DbType = DbType.Int32;    
				paramTwo.Size = 10;     
				paramTwo.Direction = ParameterDirection.Output;     
				cmd.Parameters.Add (paramTwo);

				// Execute the stored proc.     
				var count = cmd.ExecuteScalar ();     

				// Return output param.     
				var outParam = (int)cmd.Parameters ["@outParam"].Value;

				// This can be made on the parameter directly
				var outParam2 = (int)paramTwo.Value;

				if (outParam != outParam2) {
					throw new Exception ("Something wen't terribly wrong...");
				}

				outPutParam = outParam;
				return (long)count;
			} 
		}

		public static void ExampleWithDataReader (out int setCount, out int recordCount)
		{
			setCount = 0;
			recordCount = 0;

			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var dbFactory = DbProviderFactories.GetFactory (providerName);

			using (var cn = dbFactory.CreateConnection ()) {     
				cn.ConnectionString = connectionString;     
				cn.Open (); 

				var cmd = cn.CreateCommand ();
				cmd.CommandText = "spGetFoo";
				cmd.Connection = cn;

				cmd.CommandType = CommandType.StoredProcedure;     							

				using (var dr = cmd.ExecuteReader ()) {
					do {
						setCount++;
						do {
						} while (dr.Read ());

						recordCount++;
					} while (dr.NextResult ());
				}
			} 
		}
	}
}