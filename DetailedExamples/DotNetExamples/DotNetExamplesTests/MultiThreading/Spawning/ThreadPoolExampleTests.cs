using NUnit.Framework;
using System;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class ThreadPoolExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new ThreadPoolExample ();

			Assert.IsTrue (sut.IsSet);
		}
	}
}