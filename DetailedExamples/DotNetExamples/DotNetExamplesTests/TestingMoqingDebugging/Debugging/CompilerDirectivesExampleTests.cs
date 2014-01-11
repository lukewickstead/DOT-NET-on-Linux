using NUnit.Framework;
using System;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class CompilerDirectivesExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new CompilerDirectivesExample ();
			sut.Run ();

			Assert.IsTrue (sut.HitOne.HasValue);
			Assert.IsTrue (sut.HitOne.Value);
			Assert.IsTrue (sut.HitTwo.HasValue);
			Assert.IsTrue (sut.HitTwo.Value);
		}
	}
}