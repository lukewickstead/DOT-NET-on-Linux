using NUnit.Framework;
using System;
using System.Threading;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class ThreadStartExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new ThreadStartExample ();

			Assert.IsTrue(sut.IsSet);
		}
	}
}