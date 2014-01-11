using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ADODotNetAndMySQL.DAL.SQL
{
	public class SQLDefinition
	{
		/// <summary>
		/// The delete from: "DELETE FROM {0}"
		/// </summary>
		public static string DeleteFrom = "DELETE FROM {0}";

		/// <summary>
		/// The delete from where: "DELETE FROM {0} WHERE {1} IN ({2})"
		/// </summary>
		public static string DeleteFromWhere = "DELETE FROM {0} WHERE {1} IN ({2})";

		/// <summary>
		/// The insert into: "INSERT INTO {0} ({1}) VALUES {2}"
		/// </summary>
		public static string InsertInto = "INSERT INTO {0} ({1}) VALUES {2}";

		/// <summary>
		/// The select from: "SELECT {0} FROM {1}"
		/// </summary>
		public static string SelectFrom = "SELECT {0} FROM {1}";

		/// <summary>
		/// The select from where: "SELECT {0} FROM {1} WHERE {2} IN ({3})"
		/// </summary>
		public static string SelectFromWhere = "SELECT {0} FROM {1} WHERE {2} IN ({3})";

		/// <summary>
		/// The UPDATE: "UPDATE {0} SET {1} WHERE {2} = {3}"
		/// </summary>
		public static string UPDATE = "UPDATE {0} SET {1} WHERE {2} = {3}";

		/// <summary>
		/// The count star: COUNT(*)
		/// </summary>
		public static string CountStar = "COUNT(*)";
	}
}

