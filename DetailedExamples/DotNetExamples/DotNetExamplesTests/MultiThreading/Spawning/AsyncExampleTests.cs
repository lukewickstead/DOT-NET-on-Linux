using NUnit.Framework;
using System;
using MultiThreading.Spawning;
using System.Threading;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class AsyncExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new AsyncExample ();
			var result =  sut.RunWithReturn ();

			Thread.Sleep (1);

			Assert.IsTrue (result.Result);
		}

		[Test ()]
		public void TestCaseNo ()
		{
			var sut = new AsyncExample ();
			sut.RunNoReturn ();

			Thread.Sleep (10);

			Assert.IsTrue (sut.IsSet);
		}
	}
}