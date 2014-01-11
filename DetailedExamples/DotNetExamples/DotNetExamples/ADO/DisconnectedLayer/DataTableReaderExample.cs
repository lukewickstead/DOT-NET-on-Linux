using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.DisconnectedLayer
{
	public class DataTableReaderExample
	{
		public DataSet DS { get; private set; }
		public DataTable Table { get; private set; }

		public DataTableReaderExample ()
		{
			DS = FillDataSetExample.Example ();
			Table = DS.Tables [0];
		}

		public bool Example ()
		{

			using (DataTableReader reader = Table.CreateDataReader ()) {
				while (reader.Read ()) {

					// Access via the fields name or ordinal position
					var aValue = (int)reader [0];
					var bValue = (int)reader ["idAnotherTable"];

					if (aValue < 0 || bValue < 0 || aValue.GetType () != typeof(int) || bValue.GetType () != typeof(int)) {
						throw new Exception ("An Issue");
					}

					// Access should be preferred through strongly typed values
					var isNull = reader.IsDBNull (0);
					if (isNull) {
						throw new Exception ("An Issue");
					}

					var aString = reader.GetString (1);
					if (aString.Length == 0 || aString.GetType () != typeof(string)) {
						throw new Exception ("An Issue");
					}

					var anInt = reader.GetInt32 (2);
					if (anInt == 0 || anInt.GetType () != typeof(int)) {
						throw new Exception ("An Issue");
					}

					var aDecimal = reader.GetDecimal (3);
					if (aDecimal == 0 || aDecimal.GetType () != typeof(decimal)) {
						throw new Exception ("An Issue");
					}				

					// Access the .NET field type or the data providers type
					Type aType = reader.GetFieldType (0);
					Type bType = reader.GetProviderSpecificFieldType (0);

					if (aType != typeof(int) || bType != typeof(int)) {
						throw new Exception ("An Issue");
					}

					// Access field name and ordinal position
					var fieldName = reader.GetName (1);
					int position = reader.GetOrdinal ("StringField"); 
				
					if (fieldName != "StringField" || position != 1) {
						throw new Exception ("An Issue");
					}
				}

				return true;
			}
		}
	}
}