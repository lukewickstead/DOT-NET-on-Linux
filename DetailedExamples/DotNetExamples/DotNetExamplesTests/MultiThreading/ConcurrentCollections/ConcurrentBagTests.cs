using NUnit.Framework;
using System;

namespace MultiThreading.ConcurrentCollections.Tests
{
	[TestFixture]
	public class ConcurrentBagTests
	{
		[Test]
		public void TestCase ()
		{
			var sut = new ConcurrentBag ();
			sut.Run ();
			Assert.AreEqual (10, sut.Count);
		}
	}
}