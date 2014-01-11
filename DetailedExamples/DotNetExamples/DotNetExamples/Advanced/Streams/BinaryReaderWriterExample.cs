using System;
using System.IO;

namespace Advanced.Streams
{
	public class BinaryReaderWriterExample
	{
		public static TheData Readata (string fileName)
		{
			var theData = new TheData ();

			using (var fs = new FileStream (fileName, FileMode.Open)) {
				using (var br = new BinaryReader (fs)) { 
				
					theData.ABool = br.ReadBoolean ();
					theData.AChar = br.ReadChar ();
					theData.ADouble = br.ReadDouble ();
					theData.AnInt = br.ReadInt32 ();
				}

				return theData;
			} 
		}

		public static string WriteData (TheData theData)
		{
			var aFileName = Path.GetTempFileName ();

			using (var fs = new FileStream (aFileName, FileMode.Create)) {
				using (var bw = new BinaryWriter (fs)) { 

					bw.Write (theData.ABool);
					bw.Write (theData.AChar);
					bw.Write (theData.ADouble);
					bw.Write (theData.AnInt);
				}

				return aFileName;
			} 
		}
	}
}