using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.ConnectedLayer
{
	public class DataReaderExample
	{
		public static int Example ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var dbFactory = DbProviderFactories.GetFactory (providerName);

			var count = 0;

			using (var cn = dbFactory.CreateConnection ()) {     
				cn.ConnectionString = connectionString;     
				cn.Open (); 

				var cmd = cn.CreateCommand ();

				cmd.CommandText = "Select * from AnotherTable";
				cmd.CommandType = CommandType.Text;
				cmd.Connection = cn;

				using (var dr = cmd.ExecuteReader ()) {    
					while (dr.Read ()) {
						var val1 = (string)dr ["StringField"];
						var val2 = (int)dr [0];

						// Get the field name or its ordinal position
						var name = dr.GetName (1);
						var pos = dr.GetOrdinal ("StringField");

						// Strongly Types Data
						var val3 = dr.GetInt32 (2);
						var val4 = dr.GetDecimal (3);
						var val5 = dr.GetDouble (3);
						var val6 = dr.GetString (2);

						var isNull = dr.IsDBNull (0);

						var fdType = dr.GetProviderSpecificFieldType (0);

						if (val1.GetType () != typeof(string)) {
							return -1;
						} 

						if (val2.GetType () != typeof(int)) {
							return -1;
						}

						if (name != "StringField") {
							return -1;
						} 

						if (pos != 1) {
							return -1;
						}

						if (val3.GetType () != typeof(int)) {
							return -1;
						} 

						if (val4.GetType () != typeof(decimal)) {
							return -1;
						} 

						if (val5.GetType () != typeof(double)) {
							return -1;
						} 

						if (val6.GetType () != typeof(string)) {
							return -1;
						} 

						if (fdType != typeof(int)) {
							return -1;
						} 

						if (isNull) {
							return -1;
						}

						count++;
					}
				}
			} 

			return count;
		}
	}
}