using NUnit.Framework;
using System;
using Advanced.AdvancedFeatures;

namespace Advanced.AdvancedFeatures.Tests
{
	[TestFixture ()]
	public class IndexedMethodExampleTest
	{
		[Test ()]
		public void TestIntIndexedClass ()
		{
			var foo = new IntIndexedClass ();

			foo [0] = "Boo";

			Assert.AreEqual ("Boo", foo [0]);
		}

		[Test ()]
		public void TestStringIndexedClass ()
		{
			var foo = new StringIndexedClass ();

			foo ["One"] = "Boo";

			Assert.AreEqual ("Boo", foo ["One"]);
		}

		[Test ()]
		public void TestDblIntIndexedClass ()
		{
			var foo = new DblIntIndexedClass ();

			foo [1, 2] = 3;

			Assert.AreEqual (3, foo [1, 2]);
		}
	}
}