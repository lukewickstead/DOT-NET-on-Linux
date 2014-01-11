using NUnit.Framework;
using System;
using System.Threading;
using System.Diagnostics;

namespace MultiThreading.ProcessAppDomains.Tests
{
	[TestFixture ()]
	public class ThreadBasicsTests
	{
		[Test ()]
		public void TestCase ()
		{
			var aThread = Thread.CurrentThread;

			//aThread.Name = "Thready McFreddy"; - cannot rename a thread already named.

			Assert.AreEqual ("TestRunnerThread", aThread.Name);
			Assert.IsTrue (aThread.IsAlive);
			Assert.GreaterOrEqual(1, Process.GetProcesses () [0].Threads.Count);
			Assert.IsTrue(aThread.IsBackground);
			Assert.AreEqual(ThreadPriority.Lowest, aThread.Priority);
			Assert.AreEqual(System.Threading.ThreadState.Background, aThread.ThreadState);
		}
	}
}

