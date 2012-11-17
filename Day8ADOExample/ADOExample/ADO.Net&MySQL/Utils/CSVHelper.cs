using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ADODotNetAndMySQL.Utils
{
	public class CSVHelper
	{
		public static Char COMMA = ',';

		public static string GetCSVString<T> (List<T> entries)
		{
			return string.Join (COMMA.ToString (), entries.ToArray ());
		}
	}

}

