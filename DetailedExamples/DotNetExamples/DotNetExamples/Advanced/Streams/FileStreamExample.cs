using System;
using System.IO;
using System.Text;

namespace Advanced.Streams
{
	public class FileStreamExample
	{
		public static string WriteData (string aString, out int size)
		{
			var aFileName = Path.GetTempFileName ();

			byte[] ba = Encoding.Default.GetBytes (aString);   

			using (var fs = new FileStream (aFileName, FileMode.Create)) {
				fs.Write (ba, 0, ba.Length); 		
			}

			size = ba.Length;

			return aFileName;
		}

		public static string ReadData (string aFileName, int size)
		{
			byte[] rb = new byte[size];

			using (var fs = new FileStream (aFileName, FileMode.Open)) {
				for (int i = 0; i < fs.Length; i++) {
					rb [i] = (byte)fs.ReadByte ();
				}
			}

			return Encoding.Default.GetString (rb); 
		}
	}
}