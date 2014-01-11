using NUnit.Framework;
using System;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class ConditionalAttributeExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new ConditionalAttributeExample ();

			Assert.IsTrue (sut.Hit.HasValue);
			Assert.IsTrue (sut.Hit.Value);
		}
	}
}