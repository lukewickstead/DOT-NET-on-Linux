using ADODotNetAndMySQL.DAL.Models;
using ADODotNetAndMySQL.DAL.SQL;
using System.Collections.Generic;
using System.Data;

namespace ADODotNetAndMySQL.DAL.Repositories
{
	public abstract class RepositoryBase<T> : RepositoryADOAdapter
	{
		private SQLHelper<T> sqlHelper;

		public RepositoryBase (SQLHelper<T> sqlHelper)
		{
			this.sqlHelper = sqlHelper;
		}

		public int CountAll ()
		{
			string sqlCommand = sqlHelper.Count ();

			return ExecuteScalar<int> (sqlCommand);
		}

		public void DeleteAll ()
		{
			string sqlCommand = sqlHelper.DeleteFrom ();

			ExecuteCommand (sqlCommand);
		}

		public void Delete (List<long> ids)
		{
			string sqlCommand = sqlHelper.DeleteFromWhere (ids);

			ExecuteCommand (sqlCommand);
		}

		public void  Insert (List<T> models)
		{
			string sqlCommand = sqlHelper.InsertInto (models);

			ExecuteCommand (sqlCommand);
		}

		public IEnumerable<T> GetAll ()
		{			
			string sqlCommand = sqlHelper.SelectAll ();

			var dataTable = GetDataTable (sqlCommand, sqlHelper.GetTableName ());		

			return GetModels (dataTable);
		}

		public IEnumerable<T> Get (List<long> ids)
		{
			string sqlCommand = sqlHelper.Select<T> (ids);

			var dataTable = GetDataTable (sqlCommand, sqlHelper.GetTableName ());		

			return GetModels (dataTable);
		}

		public void Update (T model)
		{
			string sqlCommand = sqlHelper.Update (model);

			ExecuteCommand (sqlCommand);
		}

		protected abstract IEnumerable<T> GetModels (DataTable dataRow);
	}
}

