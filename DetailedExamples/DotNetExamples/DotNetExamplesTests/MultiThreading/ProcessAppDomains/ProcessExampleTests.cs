using NUnit.Framework;
using System;

namespace MultiThreading.ProcessAppDomains.Tests
{
	[TestFixture ()]
	public class ProcessExampleTests
	{
		[Test ()]
		public void TestGetRunningProcessWithLocal ()
		{
			Assert.Greater (ProcessExample.GetRunningProcesses (string.Empty, string.Empty).Length, 0);
		}

		[Test ()]
		public void TestGetRunningProcessWithComputerName ()
		{
			Assert.Greater (ProcessExample.GetRunningProcesses (string.Empty, Environment.MachineName).Length, 0);
		}
	}
}