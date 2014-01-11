using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace Advanced.Serialization
{
	public class SoapFormatterExample
	{
		public static string Serialize<T> (T model)
		{
			var aFileName = Path.GetTempFileName ();

			using (var fs = new FileStream (aFileName, FileMode.Create)) { 

				var ser = new SoapFormatter ();
				ser.Serialize (fs, model);
			}				

			return aFileName;
		}

		public static T Deserialize<T> (string aFileName)
		{
			using (Stream fs = File.OpenRead (aFileName)) {     
				var ser = new SoapFormatter ();   
				return (T)ser.Deserialize (fs);    
			}
		}
	}
}