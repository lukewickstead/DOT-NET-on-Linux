using NUnit.Framework;
using System;

namespace MultiThreading.ThreadSynchronization.Tests
{
	[TestFixture ()]
	public class ThreadJoinExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new ThreadJoinExample ();

			Assert.AreEqual (2, sut.Counter);
		}
	}
}