using NUnit.Framework;
using System;
using Advanced.Streams;

namespace Advanced.Streams.Tests
{
	[TestFixture ()]
	public class GZipStreamExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aString = "This is a string";
			int size; 

			var aFilePath = GZipStreamExample.WriteData (aString, out size);
			var aOutString = GZipStreamExample.ReadData (aFilePath, size);

			Assert.AreEqual (aString, aOutString);
		}
	}
}