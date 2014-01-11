using NUnit.Framework;
using System;
using Advanced.Streams;

namespace Advanced.Streams.Tests
{
	[TestFixture ()]
	public class BinaryReaderWriterTests
	{
		[Test ()]
		public void TestCase ()
		{
			var theData = new TheData (){ ABool = true, AChar = 'A', ADouble = 2, AnInt = 33 };

			var aFileName = BinaryReaderWriterExample.WriteData(theData);
			var thisData = BinaryReaderWriterExample.Readata (aFileName);

			Assert.AreEqual (theData, thisData);
		}
	}
}