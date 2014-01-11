using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.DisconnectedLayer
{
	public class QueryingDataTableExample
	{
		public DataSet DS { get; private set; }
		public DataTable Table { get; private set; }

		public QueryingDataTableExample ()
		{
			DS = FillDataSetExample.Example ();
			Table = DS.Tables [0]; 
		}

		public DataRow[] SelectAllExample ()
		{
			return DS.Tables[0].Select ();
		}

		public DataRow[] SelectExample ()
		{
			var aValue = (string)Table.Rows [0] ["StringField"];

			return Table.Select (string.Format ("StringField='{0}'", aValue));   
		}

		public DataRow[] SortSingleFieldExample ()
		{
			return Table.Select (string.Empty, "StringField"); 
		}

		public DataRow[] SortMultipleFieldExample ()
		{
			return Table.Select (string.Empty, "StringField, IntField");
		}

		public DataRow[] SortDescendingExample ()
		{
			return Table.Select (string.Empty, "StringField DESC");
		}
	}
}