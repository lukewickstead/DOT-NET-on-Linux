using NUnit.Framework;
using System;
using AssembliesReflectionSecurity.Security;

namespace AssembliesReflectionSecurity.Security.Tests
{
	[TestFixture ()]
	[Ignore ("Requires Certificate Server")]
	public class X509ExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aString = "This is a string";

			Assert.IsTrue (X509Example.SignAndVerify (aString));
		}
	}
}