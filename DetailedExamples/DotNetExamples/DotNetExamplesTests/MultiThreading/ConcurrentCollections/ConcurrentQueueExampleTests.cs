using NUnit.Framework;
using System;

namespace MultiThreading.ConcurrentCollections.Tests
{
	[TestFixture ()]
	public class ConcurrentQueueExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new ConcurrentQueueExample ();
			sut.Run ();

			Assert.AreEqual (10, sut.Put);
			Assert.AreEqual (10, sut.Take);
		}
	}
}