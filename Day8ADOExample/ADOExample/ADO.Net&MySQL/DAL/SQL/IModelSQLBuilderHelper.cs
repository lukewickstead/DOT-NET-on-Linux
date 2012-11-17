using System;

using ADODotNetAndMySQL.DAL.Models;

namespace ADODotNetAndMySQL.DAL.SQL
{
	public interface IModelSQLBuilderHelper<T>
	{
		string GetTableName ();

		long GetId (T model);

		string  GetIdFieldName ();

		string GetValues (T model);

		string GetValuesWithID (T model);

		string GetFields ();

		string GetFieldswithID ();

		string GetSetString (T model);		
	}
}

