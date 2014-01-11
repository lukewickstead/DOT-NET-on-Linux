using System;
using ADODotNetAndMySQL.DAL.Models;
using Fields = ADODotNetAndMySQL.DAL.Schema.SampleTableSchema.Fields;

namespace ADODotNetAndMySQL.DAL.SQL
{
	public class SampleTableSQLBuilderHelper :IModelSQLBuilderHelper<SampleTable>
	{
		public string GetTableName ()
		{
			return ADODotNetAndMySQL.DAL.Schema.SampleTableSchema.TableName;
		}

		public string GetIdFieldName ()
		{
			return Fields.Id;
		}

		public long GetId (SampleTable model)
		{
			return model.Id;
		}

		public string GetValues (SampleTable model)
		{
			return string.Format ("('{0}', {1}, '{2:yyyy-MM-dd}')", model.Name, model.Height, model.DateOfBirth);
		}

		public string GetValuesWithID (SampleTable model)
		{
			return string.Format ("({0}, {1})", model.Id, GetValues (model));
		}

		public string GetFields ()
		{
			return string.Format ("{0}, {1}, {2}", Fields.Name, Fields.Height, Fields.DateOfBirth);
		}

		public string GetFieldswithID ()
		{
			return string.Format ("{0}, {1}", Fields.Id, GetFields ());
		}

		public string GetSetString (SampleTable model)
		{
			return string.Format ("{0}='{1}', {2}={3}, {4}='{5:yyyy-MM-dd}'", 
			                      Fields.Name, model.Name, 
			                      Fields.Height, model.Height, 
			                      Fields.DateOfBirth, model.DateOfBirth);
		}
	}
}

