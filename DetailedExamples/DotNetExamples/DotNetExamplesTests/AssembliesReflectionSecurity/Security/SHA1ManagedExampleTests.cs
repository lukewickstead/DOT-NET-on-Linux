using NUnit.Framework;
using System;
using AssembliesReflectionSecurity.Security;

namespace AssembliesReflectionSecurity.Security.Tests
{
	[TestFixture ()]
	public class SHA1ManagedExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aString = "This is a string";
			var anotherString = "This is another string";

			var encryptedOne = SHA1ManagedExample.HashData (aString);
			var encryptedTwo = SHA1ManagedExample.HashData (aString);
			var encryptedThree = SHA1ManagedExample.HashData (anotherString);


			Assert.AreEqual (encryptedOne, encryptedTwo);
			Assert.AreNotEqual (encryptedOne, encryptedThree);
		}
	}
}

