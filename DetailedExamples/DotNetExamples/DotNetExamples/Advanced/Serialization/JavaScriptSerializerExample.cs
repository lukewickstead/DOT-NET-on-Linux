using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Advanced.Serialization
{
	public class JavaScriptSerializerExample
	{
		public static string Serialize<T> (List<T> models)
		{
			var serializer = new JavaScriptSerializer ();
			return serializer.Serialize (models);
		}

		public static List<T> Deserialize<T> (string serializedResult)
		{
			var serializer = new JavaScriptSerializer ();	
			return serializer.Deserialize<List<T>> (serializedResult);
		}
	}
}