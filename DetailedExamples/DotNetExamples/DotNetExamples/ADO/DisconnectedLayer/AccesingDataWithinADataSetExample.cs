using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;

namespace ADO.DisconnectedLayer
{
	public class AccesingDataWithinADataSetExample
	{
		private DataSet dataSet;

		public AccesingDataWithinADataSetExample ()
		{
			dataSet =  FillDataSetExample.Example ();
		}

		public void AccesingDataSetExample (out string name, out int propertyCount)
		{
			var tables = dataSet.Tables;

			name = dataSet.DataSetName;

			PropertyCollection properties = dataSet.ExtendedProperties;
		
			properties.Add ("Connected", DateTime.Now);

			propertyCount = 0;

			foreach (DictionaryEntry de in properties) {
				var aKey = de.Key;
				var aValue = de.Value;

				propertyCount++;
			}	
		}

		public void AccessingDataTable (out int tableCount, out string tableName)
		{
			DataTableCollection tables = dataSet.Tables;

			DataTable dataTable = dataSet.Tables [0];
			DataTable namedDataTable = dataSet.Tables ["AnotherTable"];

			tableName = dataTable.TableName;
			var parentDataSet = dataTable.DataSet;
			var primaryKey = dataTable.PrimaryKey;

			tableCount = tables.Count;
			//var pkName = primaryKey [0].ColumnName; // TODO: Synch - This won't be set until fill schema is called.
		}

		public void AccessingDataRow (out int rowCount)
		{
			DataTable dataTable = dataSet.Tables [0];

			DataRowCollection rows = dataTable.Rows;

			var count = dataTable.Rows.Count;

			DataRow row = dataTable.Rows [0];

			rowCount = rows.Count;
		}

		public DataColumn AccessingDataColumn (out int colCount)
		{
			DataTable dataTable = dataSet.Tables [0];

			colCount = dataTable.Columns.Count;

			DataColumnCollection columns = dataTable.Columns;
			DataColumn column = dataTable.Columns [0];
			DataColumn columnTwo = dataTable.Columns ["Field"];

			int idValue = (int)dataTable.Rows [0] [0];
			string columnFour = (string)dataTable.Rows [0] ["StringField"];

			var columnName = column.ColumnName;
			var ParentDataTable = column.Table;
			var position = column.Ordinal;

			var defaultValue = column.DefaultValue;
			var isNullable = column.AllowDBNull;

			return column;
		}
	}
}