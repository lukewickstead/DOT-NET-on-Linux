using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using ADODotNetAndMySQL.DAL.SQL;
using ADODotNetAndMySQL.Utils;

namespace ADODotNetAndMySQL.DAL.SQL
{
	public class SQLHelper<T>
	{
		private IModelSQLBuilderHelper<T> modelHelper;

		public SQLHelper (IModelSQLBuilderHelper<T> modelHelper)
		{
			this.modelHelper = modelHelper;
		}

		public string Count ()
		{
			return string.Format (SQLDefinition.SelectFrom, SQLDefinition.CountStar, modelHelper.GetTableName ());
		}

		public string DeleteFrom ()
		{
			return string.Format (SQLDefinition.DeleteFrom, modelHelper.GetTableName ());
		}

		public string DeleteFromWhere (List<long> ids)
		{		
			return string.Format (SQLDefinition.DeleteFromWhere, modelHelper.GetTableName (), modelHelper.GetIdFieldName (), CSVHelper.GetCSVString<long> (ids));
		}

		public string InsertInto (List<T> models)
		{

			var stringBuilder = new StringBuilder ();
			var count = 0;

			foreach (var model in models) {

				count ++;

				stringBuilder.Append (modelHelper.GetValues (model));
				stringBuilder.Append (count == models.Count () ? ";" : ",");				
			}

			return string.Format (SQLDefinition.InsertInto, modelHelper.GetTableName (), modelHelper.GetFields (), stringBuilder.ToString ());
		}

		public string SelectAll ()
		{
			return string.Format (SQLDefinition.SelectFrom, modelHelper.GetFieldswithID (), modelHelper.GetTableName ());
		}

		public string Select<Type> (List<long> ids)
		{
			return string.Format (SQLDefinition.SelectFromWhere, modelHelper.GetFieldswithID (), modelHelper.GetTableName (), modelHelper.GetIdFieldName (), CSVHelper.GetCSVString<long> (ids));
		}

		public string Update (T model)
		{
			return string.Format (SQLDefinition.UPDATE, modelHelper.GetTableName (), modelHelper.GetSetString (model), modelHelper.GetIdFieldName (), modelHelper.GetId (model));
		}

		public string GetTableName ()
		{
			return modelHelper.GetTableName ();
		}
	}

}

