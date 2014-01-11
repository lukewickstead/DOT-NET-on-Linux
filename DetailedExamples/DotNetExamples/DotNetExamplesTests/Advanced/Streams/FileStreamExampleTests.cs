using NUnit.Framework;
using System;
using Advanced.Streams;

namespace Advanced.Streams.Tests
{
	[TestFixture ()]
	public class FileStreamExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aString = "This is a string";
			int size; 

			var aFilePath = FileStreamExample.WriteData (aString, out size);
			var aOutString = FileStreamExample.ReadData (aFilePath, size);

			Assert.AreEqual (aString, aOutString);
		}
	}
}