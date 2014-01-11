using NUnit.Framework;
using System;
using MultiThreading.ThreadSynchronization;

namespace MultiThreading.ThreadSynchronization.Tests
{
	[TestFixture ()]
	public class InterlockedExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new InterlockedExample();


			Assert.AreEqual (20, sut.ANumber);
		}
	}
}

