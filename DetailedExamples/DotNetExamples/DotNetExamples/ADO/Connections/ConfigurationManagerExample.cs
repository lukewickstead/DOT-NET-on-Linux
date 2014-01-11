using System;
using System.Configuration;

namespace ADO.Connections
{
	public class ConfigurationManagerExampleADO
	{
		public static void GetConnectionString (out string connection, out string provider)
		{
			var myConnection = ConfigurationManager.ConnectionStrings ["MyDatabase"];

			provider = myConnection.ProviderName;
			connection = myConnection.ConnectionString;
		}
	}
}