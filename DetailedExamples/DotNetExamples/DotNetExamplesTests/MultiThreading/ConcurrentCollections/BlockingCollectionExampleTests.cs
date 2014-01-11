using NUnit.Framework;
using System;

namespace MultiThreading.ConcurrentCollections.Tests
{
	[TestFixture ()]
	public class BlockingCollectionExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new BlockingCollectionExample ();

			var result = sut.Run ();

			Assert.AreEqual (10, result);
		}

		[Test ()]
		public void TestGetConsumingEnumerablexample ()
		{
			var sut = new BlockingCollectionExample ();

			var result = sut.ConsumingEnumerablexample ();

			Assert.AreEqual (10, result);
		}
	}
}