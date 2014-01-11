using NUnit.Framework;
using System;
using AssembliesReflectionSecurity.Security;

namespace AssembliesReflectionSecurity.Security.Tests
{
	[TestFixture ()]
	public class RSAEncryptionExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aString = "This is a string";
			using (var sut = new RSAEncryptionExample ()) {
				var encrypted = sut.Encrypt (aString);
				var decrypted = sut.Decrypt (encrypted);
				Assert.AreEqual (aString, decrypted);
			}
		}
	}
}