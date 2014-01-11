using NUnit.Framework;
using System;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class TimerExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new TimerExample ();

			Assert.Greater (100, sut.Count);
		}
	}
}