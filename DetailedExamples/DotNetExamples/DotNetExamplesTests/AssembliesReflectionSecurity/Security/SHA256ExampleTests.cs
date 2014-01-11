using NUnit.Framework;
using System;
using AssembliesReflectionSecurity.Security;

namespace AssembliesReflectionSecurity.Security.Tests
{
	[TestFixture ()]
	public class SHA256ExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aString = "This is a string";
			var anotherString = "This is another string";

			var encryptedOne = SHA256Example.Hash (aString);
			var encryptedTwo = SHA256Example.Hash (aString);
			var encryptedThree = SHA256Example.Hash (anotherString);

			Assert.AreEqual (encryptedOne, encryptedTwo);
			Assert.AreNotEqual (encryptedOne, encryptedThree);
		}
	}
}