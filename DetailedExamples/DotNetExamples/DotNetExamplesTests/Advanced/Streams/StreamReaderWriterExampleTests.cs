using NUnit.Framework;
using System;
using Advanced.Streams;

namespace Advanced.Streams.Tests
{
	[TestFixture ()]
	public class StreamReaderWriterExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var theData = new TheData (){ ABool = true, AChar = 'A', ADouble = 2, AnInt = 33 };

			var aFilePath = StreamReaderWriterExample.WriteData (theData);
			var aOutStrings = StreamReaderWriterExample.ReadData (aFilePath);

			Assert.AreEqual (theData.ABool.ToString (), aOutStrings [0]);
			Assert.AreEqual (theData.AChar.ToString (), aOutStrings [1]);
			Assert.AreEqual (theData.ADouble.ToString (), aOutStrings [2]);
			Assert.AreEqual (theData.AnInt.ToString (), aOutStrings [3]);
		}
	}
}