using System;
using System.IO;
using System.Collections.Generic;

namespace Advanced.Streams
{
	public class StringReaderWriterExample
	{
		public static List<string> ReadData (string aString)
		{
			var strings = new List<string> ();

			using (var sr = new StringReader (aString)) {     
				string input = null;     
				while ((input = sr.ReadLine ()) != null) {				
					strings.Add (input);				
				}
			}

			return strings;
		}

		public static string WriteData (List<string> strings)
		{
			using (var sw = new StringWriter ()) {
				foreach (var aString in strings) {
					sw.WriteLine (aString);
				}				

				return sw.ToString ();
			}
		}
	}
}