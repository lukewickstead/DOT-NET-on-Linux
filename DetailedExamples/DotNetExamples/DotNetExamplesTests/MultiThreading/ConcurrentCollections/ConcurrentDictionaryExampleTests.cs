using NUnit.Framework;
using System;
using MultiThreading.ConcurrentCollections;

namespace MultiThreading.ConcurrentCollections.Tests
{
	[TestFixture ()]
	public class ConcurrentDictionaryExampleTests
	{
		[Test ()]
		public void TestTryAddUpdate ()
		{
			var sut = new ConcurrentDictionaryExample ();
			sut.Run ();
			Assert.AreEqual (285, sut.Result);
		}

		[Test ()]
		public void TestAddOrUpdate ()
		{
			var sut = new ConcurrentDictionaryExample ();
			sut.AddOrUpdate ();
			Assert.AreEqual (12, sut.Result);
		}

		[Test ()]
		public void TestGetOrAdd ()
		{
			var sut = new ConcurrentDictionaryExample ();
			sut.GetOrAdd ();
			Assert.AreEqual (12, sut.Result);
		}
	}
}