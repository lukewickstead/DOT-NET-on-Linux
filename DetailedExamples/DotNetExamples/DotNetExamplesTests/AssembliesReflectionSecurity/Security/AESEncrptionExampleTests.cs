using NUnit.Framework;
using System;

namespace AssembliesReflectionSecurity.Security.Tests
{
	[TestFixture ()]
	public class AESEncrptionExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aString = "This is a string";

			byte[] key;
			byte[] iV;

			var encrypted = AESEncrptionExample.Encrypt (aString, out key, out iV);
			var decrypted = AESEncrptionExample.Decrypt (encrypted, key, iV);

			Assert.AreEqual (aString, decrypted);
		}
	}
}