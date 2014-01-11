using NUnit.Framework;
using System;
using System.Threading;

namespace MultiThreading.ThreadSynchronization.Tests
{
	[TestFixture ()]
	public class MonitorExampleTests
	{
		[Test ()]
		//[ExpectedException(typeof(SynchronizationLockException))]
		public void TestEnterExample ()
		{
			var sut = new MonitorExample ();

			sut.EnterExample ();

			Assert.AreEqual (2, sut.Counter);
		}

		[Test ()]
		[ExpectedException(typeof(SynchronizationLockException))]
		public void TestTryEnterExampple ()
		{
			var sut = new MonitorExample ();
			sut.TryEnterExampple ();
			Assert.AreEqual (1, sut.Counter);
		}
	}
}