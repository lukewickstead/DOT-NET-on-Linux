using System;
using System.IO;
using System.Xml.Serialization;

namespace Advanced.Serialization
{
	public class XMLSerializerExample
	{
		public static string Serialize<T> (T model)
		{
			var aFileName = Path.GetTempFileName ();

			using (var fs = new FileStream (aFileName, FileMode.Create)) { 

				var ser = new XmlSerializer (typeof(T));
				ser.Serialize (fs, model);
			}				

			return aFileName;
		}

		public static T Deserialize<T> (string aFileName)
		{
			using (Stream fs = File.OpenRead (aFileName)) {     
				var ser = new XmlSerializer (typeof(T));   
				return (T)ser.Deserialize (fs);    
			}
		}
	}
}


/*
using System;
using System.IO;
using System.Xml.Serialization;

namespace Advanced.Serialization
{
	public class XMLSerializerExample
	{
		public XMLSerializerExample ()
		{
			using (var fs = new FileStream ("data.dat", FileMode.Create)) {
				var anObject = new MyModel (){ AnInt = 1, AString = "A", ABool = true };
				var xs = new XmlSerializer (typeof(MyModel));				     
				xs.Serialize (fs, anObject);   
			} 		

			using (var fs = File.OpenRead ("data.dat")) {
				var xs = new XmlSerializer (typeof(MyModel));				     
				var anObject = (MyModel)xs.Deserialize (fs);    
			}
		}
	}
}
*/