using NUnit.Framework;
using System;

namespace MultiThreading.ConcurrentCollections.Tests
{
	[TestFixture ()]
	public class ConcurrentStackExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new ConcurrentStackExample ();
			sut.Example ();

			Assert.AreEqual (10, sut.Take);
		}

		[Test ()]
		public void TestCaseTwo ()
		{
			var sut = new ConcurrentStackExample ();
			Assert.AreEqual(2, sut.ConcurrentStackExampleRange ());
		}
	}
}