using System;
using NUnit.Framework;
using Advanced.Generics.Tests;

namespace Advanced.Generics.Tests
{
	[TestFixture()]
	public class PrimativeTypeTryParseTests
	{
		[Test()]
		public void ReturnsDefaultValueWhenCanNotParse ()
		{
			Assert.AreEqual (new Nullable<int> (), "AAA".TryParse<int> ());
		}

		[Test()]
		public void ReturnsCorrectValueWhenCanParse ()
		{
			Assert.AreEqual (11, "11".TryParse<int> ());
		}

		[Test()]
		public void ReturnsCorrectTypeWhenCanParse ()
		{
			var aValue = "11".TryParse<decimal> ();

			Assert.AreEqual (11, aValue);
			Assert.IsInstanceOfType (typeof(decimal), aValue);
		}

		[Test()]
		public void ReturnsCorrectTypeWhenCanNotParse ()
		{
			var aValue = "aaa".TryParse<decimal> ();

			Assert.AreEqual (new Nullable<decimal> (), aValue);
			Assert.IsNull (aValue);
		}
	}
}

