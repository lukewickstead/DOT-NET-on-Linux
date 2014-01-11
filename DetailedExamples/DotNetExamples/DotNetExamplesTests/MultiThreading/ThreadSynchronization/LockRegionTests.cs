using NUnit.Framework;
using System;

namespace MultiThreading.ThreadSynchronization.Tests
{
	[TestFixture ()]
	public class LockRegionTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new LockRegion ();

			Assert.AreEqual (2, sut.Counter);
		}
	}
}
