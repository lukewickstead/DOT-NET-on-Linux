using System;
using System.IO;

namespace TheBasics
{
	public class FileInfoExample
	{
		public FileInfoExample ()
		{
			using (var fs = new FileInfo (@"C:\AFile.txt").Create ()) { 
			} 

			using (var fs = new FileInfo (@"C:\AFile.txt").Open (
				                FileMode.OpenOrCreate, 
				                FileAccess.ReadWrite, 
				                FileShare.None)) {
			}

			using (var fs = new FileInfo (@"C:\AFile.txt").OpenRead ()) {
			}  

			using (var fs = new FileInfo (@"C:\AFile.txt").OpenWrite ()) {
			}

			using (var sr = new FileInfo (@"C:\AFile.txt").OpenText ()) {
			}

			using (var sw = new FileInfo (@"C:\AFile.txt").CreateText ()) {
			}   

			using (var sw = new FileInfo (@"C:\AFile.txt").AppendText ()) {
			}
		}
	}
}