using NUnit.Framework;
using System;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class AsynchronousDelegatesExamplesTests
	{
		[Test ()]
		public void TestIsCompleted ()
		{ 
			var sut = new AsynchronousDelegatesExamples ();
			Assert.IsTrue (sut.IsCompleted ());			
		}

		[Test ()]
		public void TestAsyncWaitHandle ()
		{
			var sut = new AsynchronousDelegatesExamples ();
			Assert.IsTrue (sut.AsyncWaitHandle ());			
		}

		[Test ()]
		public void TestAsyncCallbackWithState ()
		{
			var sut = new AsynchronousDelegatesExamples ();
			Assert.IsTrue (sut.AsyncCallbackWithState ());			
			Assert.IsTrue (sut.CallBackCalled);			
		}
	}
}