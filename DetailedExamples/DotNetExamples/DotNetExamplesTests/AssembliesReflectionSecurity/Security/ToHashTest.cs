using NUnit.Framework;
using System;
using AssembliesReflectionSecurity.Security;

namespace AssembliesReflectionSecurity.Security.Tests
{
	[TestFixture ()]
	public class ToHashTest
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new ToHash (){ FieldString = "AString", FieldBool = true, FieldInt = 99, FieldDecimal = 66.666m };
	
			var h1 = sut.GetHashCode ();
			var h2 = sut.GetHashCode ();

			Assert.AreEqual (h1, h2);
		}
	}
}