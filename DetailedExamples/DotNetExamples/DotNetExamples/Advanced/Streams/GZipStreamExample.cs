using System;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Advanced.Streams
{
	public class GZipStreamExample
	{
		public static string  WriteData (string aString, out int size)
		{
			string filePath = Path.GetTempFileName ();

			byte[] outData = Encoding.Default.GetBytes (aString);

			using (var fileStream = File.Create (filePath)) {     

				using (var gzipStream = new GZipStream (fileStream, CompressionMode.Compress)) {
					gzipStream.Write (outData, 0, outData.Length); 
				}
			}

			size = outData.Length;

			return filePath;
		}

		public static string ReadData (string aFilePath, int size)
		{
			using (var gzipStream = new GZipStream (File.OpenRead (aFilePath), CompressionMode.Decompress)) {

				byte[] inData = new byte[size];

				gzipStream.Read (inData, 0, size);
	
				return Encoding.Default.GetString (inData);
			}
		}
	}
}