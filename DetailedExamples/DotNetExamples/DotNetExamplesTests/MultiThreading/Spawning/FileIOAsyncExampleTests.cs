using NUnit.Framework;
using System;
using System.Text;
using System.Threading;
using System.IO;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class FileIOAsyncExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aString = "This is a test";
			var aFileName = Path.GetTempFileName ();

			var sut = new FileIOAsyncExample ();
			var data =  Encoding.Default.GetBytes (aString);
			var aTask = sut.CreateAndWriteAsyncToFile (data, aFileName);

			Thread.Sleep (10);
			Assert.IsTrue(aTask.IsCompleted);

			Thread.Sleep (10);
			var output = sut.ReadFileAsync (aFileName, data.Length);
			var dataStrign =  Encoding.Default.GetString (output.Result);

			Assert.AreEqual (aString, dataStrign);			
		}
	}
}