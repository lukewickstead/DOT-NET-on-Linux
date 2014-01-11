using System;
using System.Data;

namespace ADO.DisconnectedLayer
{
	public class DataViewExample
	{
		public DataView DV;
		public DataTable DT;
		public DataTableReaderExample Reader;

		public DataViewExample ()
		{
			Reader = new DataTableReaderExample ();
			DT = Reader.Table;
			DV = new DataView (DT);   
		}

		public void ExampleEquals ()
		{		
			int minId = (int)DT.Rows [0] [0];
			DV.RowFilter = string.Format ("idAnotherTable>{0}", minId);  
		}

		public void ExampleGreaterThan ()
		{
			var firstString = DT.Rows [0] [1];

			DV.RowFilter = string.Format ("StringField ='{0}'", firstString);  
		}
	}
}