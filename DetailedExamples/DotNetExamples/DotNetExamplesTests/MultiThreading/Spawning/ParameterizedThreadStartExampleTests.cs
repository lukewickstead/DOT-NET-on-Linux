using NUnit.Framework;
using System;
using System.Threading;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class ParameterizedThreadStartExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new ParameterizedThreadStartExample ();

			Thread.Sleep (100);
			Assert.IsTrue(sut.IsSet);
		}
	}
}