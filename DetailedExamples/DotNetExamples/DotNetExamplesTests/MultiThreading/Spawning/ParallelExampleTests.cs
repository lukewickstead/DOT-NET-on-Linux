using NUnit.Framework;
using System;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class ParallelExampleTests
	{
		[Test ()]
		public void TestFor ()
		{
			var sut = new ParallelExample ();

			sut.For ();

			Assert.AreEqual (10, sut.count);
		}

		[Test ()]
		public void TestForEach ()
		{
			var sut = new ParallelExample ();

			sut.ForEach ();

			Assert.AreEqual (10, sut.count);
		}

		[Test ()]
		public void TestStop ()
		{
			var sut = new ParallelExample ();

			sut.Stop ();

			Assert.GreaterOrEqual (10, sut.count);
		}

		[Test ()]
		public void TestBreak ()
		{
			var sut = new ParallelExample ();

			sut.Break ();

			Assert.GreaterOrEqual (10, sut.count);
		}

		[Test ()]
		public void TestInvoke ()
		{
			var sut = new ParallelExample ();

			sut.Invoke ();

			Assert.AreEqual (4, sut.count);
		}
	}
}