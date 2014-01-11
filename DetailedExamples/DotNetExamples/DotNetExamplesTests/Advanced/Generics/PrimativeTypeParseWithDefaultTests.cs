using System;
using NUnit.Framework;
using Advanced.Generics;

namespace Advanced.Generics.Tests
{
	[TestFixture()]
	public class PrimativeTypeParseWithDefauyltTests
	{
		[Test()]
		public void ReturnsDefaultValueWhenCanNotParse ()
		{
			Assert.AreEqual (11, "AAA".Parse<int> (11));
		}

		[Test()]
		public void ReturnsCorrectValueWhenCanParse ()
		{
			Assert.AreEqual (11, "11".Parse<int> (1));
		}

		[Test()]
		public void ReturnsCorrectTypeWhenCanParse ()
		{
			var aValue = "11.11".Parse<decimal> (1m);

			Assert.AreEqual (11.11m, aValue);
			Assert.IsInstanceOfType (typeof(decimal), aValue);
		}

		[Test()]
		public void ReturnsCorrectTypeWhenCanNotParse ()
		{
			var aValue = "aaa".Parse<decimal> (11.11m);

			Assert.AreEqual (11.11m, aValue);
			Assert.IsInstanceOfType (typeof(decimal), aValue);
		}
	}
}

