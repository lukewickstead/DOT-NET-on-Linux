using NUnit.Framework;
using System;

namespace MultiThreading.ThreadSynchronization.Tests
{
	[TestFixture ()]
	public class ThreadStaticLocalExampleTest
	{
		[Test ()]
		public void TestThreadStatic ()
		{
			var sut = new ThreadStaticLocalExample ();
			 
			Assert.AreEqual(0, sut.DoThreadStatic ());
		}

		[Test ()]
		public void TestThreadLocal ()
		{
			var sut = new ThreadStaticLocalExample ();

			Assert.AreEqual(0, sut.DoThreadLocal ());
		}
	}
}