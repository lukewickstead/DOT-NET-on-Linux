using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.ConnectedLayer
{
	public class CommandParametersExample
	{
		public static int Example ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var dbFactory = DbProviderFactories.GetFactory (connectionDetails.ProviderName);

			using (var cn = dbFactory.CreateConnection ()) {     
				cn.ConnectionString = connectionDetails.ConnectionString;     
				cn.Open (); 

				var cmd = cn.CreateCommand ();

				cmd.CommandText = @"Insert Into MyTable (FieldA) Values (@Hello)";
				cmd.CommandType = CommandType.Text;

				var param = cmd.CreateParameter ();

				param.ParameterName = "@Hello";     
				param.DbType = DbType.String;     
				param.Value = "Value";     
				param.Direction = ParameterDirection.Input;     
				cmd.Parameters.Add (param);     

				cmd.Connection = cn;

				return cmd.ExecuteNonQuery ();     
			} 
		}
	}
}