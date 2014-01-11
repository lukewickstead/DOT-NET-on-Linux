using System;
using System.Collections.Generic;
using Advanced.Streams;
using NUnit.Framework;

namespace Advanced.Streams.Tests
{
	[TestFixture ()]
	public class StringReaderWriterExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var strings = new List<string> (){ "1", "2", "3", "4", "5" };

			var outString = StringReaderWriterExample.WriteData (strings);
			var outStrings = StringReaderWriterExample.ReadData (outString);

			Assert.AreEqual (strings, outStrings);
		}
	}
}