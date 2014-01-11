using NUnit.Framework;
using System;
using MultiThreading.ThreadSynchronization;

namespace MultiThreading.ThreadSynchronization.Tests
{
	[TestFixture ()]
	public class AutoResetEventExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new AutoResetEventExample ();
			Assert.AreEqual (3, sut.Counter); 
		}
	}
}