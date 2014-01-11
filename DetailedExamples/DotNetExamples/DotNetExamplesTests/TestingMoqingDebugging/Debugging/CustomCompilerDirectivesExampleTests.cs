using NUnit.Framework;
using System;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class CustomCompilerDirectivesExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new CustomCompilerDirectivesExample ();

			Assert.IsTrue (sut.HitOne);
			Assert.IsFalse (sut.HitTwo);
			Assert.IsTrue (sut.HitThree);
		}
	}
}