using System;
using NUnit.Framework;
using System.Data;

namespace Advanced.AdvancedFeatures.Tests
{
	[TestFixture ()]
	public class AnonymoustTypes
	{
		[Test ()]
		public void TestNested ()
		{	
			var foo = new { FirstName = "James", Surname = new { Name = "Pond" }  };
			var fooTwo = new { FirstName = "James", Surname = new { Name = "Pond" } };

			Assert.AreEqual ("James", foo.FirstName);
			Assert.AreEqual ("Pond", foo.Surname.Name);
			Assert.AreEqual (foo, fooTwo);
		}

		[Test ()]
		public void Test ()
		{
			var foo = new { FirstName = "James", Surname = "Pond" };
			var fooTwo = new { FirstName = "James", Surname = "Pond" };

			Assert.AreEqual ("James", foo.FirstName);
			Assert.AreEqual ("Pond", foo.Surname);
			Assert.AreEqual (foo, fooTwo);
		}
	}
}