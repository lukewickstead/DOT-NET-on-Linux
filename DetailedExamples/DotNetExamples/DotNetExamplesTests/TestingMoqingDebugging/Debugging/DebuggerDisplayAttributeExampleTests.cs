using NUnit.Framework;
using System;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class DebuggerDisplayAttributeExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new DebuggerDisplayAttributeExample ();
			sut.FirstName = "Sir";
			sut.LastName = "Fluffy";

			Assert.AreNotEqual ("Name = Sir Fluffy", sut.ToString ());
		}
	}
}