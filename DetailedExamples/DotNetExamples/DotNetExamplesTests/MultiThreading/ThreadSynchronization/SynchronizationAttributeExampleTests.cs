using NUnit.Framework;
using System;
using MultiThreading.ThreadSynchronization;

namespace MultiThreading.ThreadSynchronization.Tests
{
	[TestFixture ()]
	public class SynchronizationAttributeExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new SynchronizedAttributeExample ();
			sut.DoBombCounter ();
			Assert.AreEqual (4, sut.SAE.Counter); 

		}
	}
}

