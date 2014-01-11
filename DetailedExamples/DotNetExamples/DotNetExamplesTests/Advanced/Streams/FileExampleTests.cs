using System;
using System.IO;
using NUnit.Framework;

namespace Advanced.Streams.Tests
{
	[TestFixture()]
	public class FileExampleTests
	{
		[Test ()]
		public void Test ()
		{
			var aFilePath = Path.GetTempFileName ();
			var aString = "This is a string";

			File.WriteAllText (aFilePath, aString);
			string[] data = File.ReadAllLines (aFilePath);  

			Assert.AreEqual (aString, data [0]);		
		}
	}
}

