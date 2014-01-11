using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Spawning
{
	public class FileIOAsyncExample
	{
		public async Task CreateAndWriteAsyncToFile (byte[] data, string aFileName)
		{
			using (FileStream stream = new FileStream (aFileName, 
				                         FileMode.OpenOrCreate,         
				                         FileAccess.Write, 
				                         FileShare.Read, 1024 * 4, true)) {         
				await stream.WriteAsync (data, 0, data.Length);     
			}
		}

		public async Task<byte[]> ReadFileAsync (string aFileName, int length)
		{
			byte[] data = new byte[length];

			using (FileStream stream = new FileStream (aFileName, 
				                         FileMode.Open,         
				                         FileAccess.Read, 
				                         FileShare.Read, 1024 * 4, true)) {         
				await stream.ReadAsync (data, 0, data.Length);     
			}

			return data;
		}
	}
}