using System;

using ADODotNetAndMySQL.DAL.Models;

namespace ADODotNetAndMySQL.DAL.Schema
{
	public class SampleTableSchema
	{
		public static string TableName = "SampleTable";

		public static class Fields
		{
			public static string Id = "idSampleTable";
			public static string Name = "Name";
			public static string Height = "Height";
			public static string DateOfBirth = "DateOfBirth";
		}
	}
}

