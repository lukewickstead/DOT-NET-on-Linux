using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.DisconnectedLayer
{
	public class RowVersionExample
	{
		public static bool Example ()
		{
			var Reader = new DataTableReaderExample ();

			var aDataTable = Reader.Table;

			var originalValue = (string)aDataTable.Rows [0]["StringField"];
			aDataTable.Rows [0] ["StringField"] = "New Value";

			var aValue = (string)aDataTable.Rows [0] ["StringField", DataRowVersion.Original];

			return aValue == originalValue;				
		}	
	}
}