using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Advanced.Streams
{
	public class StreamReaderWriterExample
	{
		public static List<string> ReadData (string aFilePath)
		{
			var strings = new List<string> ();

			using (var fs = new FileStream (aFilePath, FileMode.Open)) {
				using (var reader = new StreamReader (fs)) {
					string input;

					while ((input = reader.ReadLine ()) != null) {	
						strings.Add (input);
					}
				}
			} 

			return strings;
		}

		public static string WriteData (TheData theData)
		{
			var aFilePath = Path.GetTempFileName ();

			using (var fs = new FileStream (aFilePath, FileMode.OpenOrCreate)) {
				using (var writer = new StreamWriter (fs)) {

					writer.WriteLine (theData.ABool); 
					writer.WriteLine (theData.AChar);
					writer.WriteLine (theData.ADouble);  
					writer.WriteLine (theData.AnInt); 
				}
			} 

			return aFilePath;
		}
	}
}