using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Advanced.Serialization
{
	public class BinaryFormatterExample
	{
		public static string Serialize<T> (T model)
		{
			var aFileName = Path.GetTempFileName ();

			using (var fs = new FileStream (aFileName, FileMode.Create)) { 
				var bf = new BinaryFormatter ();   
				bf.Serialize (fs, model);   
			}		

			return aFileName;	
		}

		public static T Deserialize<T> (string aFileName)
		{
			using (Stream fs = File.OpenRead (aFileName)) {     
				var bf = new BinaryFormatter ();   
				return (T)bf.Deserialize (fs);    
			}
		}
	}
}