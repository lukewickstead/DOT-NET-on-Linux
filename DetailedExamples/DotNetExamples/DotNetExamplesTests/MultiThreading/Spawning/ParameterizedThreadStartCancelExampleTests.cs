using NUnit.Framework;
using System;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class ParameterizedThreadStartCancelExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new ParameterizedThreadStartCancelExample ();

			Assert.IsTrue (sut.IsCancelled);
		}
	}
}