using NUnit.Framework;
using System;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class ThreadPoolCancelExampleTests
	{
		[Test ()]
		//[ExpectedException(typeof(OperationCanceledException))] // TODO: Fix
		public void TestCase ()
		{
			var sut = new ThreadPoolCancelExample ();

			Assert.IsTrue (sut.IsSet);
		}
	}
}