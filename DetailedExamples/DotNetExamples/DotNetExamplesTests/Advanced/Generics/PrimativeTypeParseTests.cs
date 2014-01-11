using System;
using NUnit.Framework;
using Advanced.Generics;

namespace Advanced.Generics.Tests
{
	[TestFixture()]
	public class PrimativeTypeParseTests
	{
		[Test()]
		public void ReturnsDefaultValueWhenCanNotParse ()
		{
			Assert.AreEqual (default(int), "AAA".Parse<int> ());
		}

		[Test()]
		public void ReturnsCorrectValueWhenCanParse ()
		{
			Assert.AreEqual (11, "11".Parse<int> ());
		}

		[Test()]
		public void ReturnsCorrectTypeWhenCanParse ()
		{
			var aValue = "11".Parse<double> ();

			Assert.AreEqual (11m, aValue);
			Assert.IsInstanceOfType (typeof(double), aValue);
		}

		[Test()]
		public void ReturnsCorrectTypeWhenCanNotParse ()
		{
			var aValue = "aaa".Parse<double> ();

			Assert.AreEqual (default(double), aValue);
			Assert.IsInstanceOfType (typeof(double), aValue);
		}
	}
}

