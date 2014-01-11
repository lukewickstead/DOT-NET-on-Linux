using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Advanced.Serialization
{
	public class DataContractJsonSerializerExample
	{
		public static string WriteObject<T> (T model)
		{
			var aFileName = Path.GetTempFileName ();

			using (var fs = new FileStream (aFileName, FileMode.Create)) { 
				var ser = new DataContractJsonSerializer (typeof(T));
				ser.WriteObject (fs, model);
			}				
				
			return aFileName;
		}

		public static T ReadObject<T> (string aFileName)
		{
			using (Stream fs = File.OpenRead (aFileName)) {     
				var ser = new DataContractJsonSerializer (typeof(T));   
				return (T)ser.ReadObject (fs);    
			}
		}
	}
}