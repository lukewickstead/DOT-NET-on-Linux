using NUnit.Framework;
using System;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class TaskExampleTests
	{
		[Test ()]
		public void TestStartNew ()
		{
			var sut = new TaskExample ();
			sut.StartNew ();

			Assert.IsTrue (sut.IsSet);
		}

		[Test ()]
		public void TestNewAndStart ()
		{
			var sut = new TaskExample ();
			sut.StartAndWait ();

			Assert.IsTrue (sut.IsSet);
		}

		[Test ()]
		public void TestStartAndRunSynchronously ()
		{
			var sut = new TaskExample ();
			sut.RunSynchronously ();

			Assert.IsTrue (sut.IsSet);
		}

		[Test ()]
		public void TestResult ()
		{
			var sut = new TaskExample ();
			var result = sut.Result ();

			Assert.IsTrue (sut.IsSet); 
			Assert.IsTrue (result);
		}

		[Test ()]
		public void TestContinuationTask ()
		{
			var sut = new TaskExample ();
			var result = sut.ContinuationTask ();

			Assert.IsTrue (sut.IsSet);
			Assert.IsFalse (result);
		}

		[Test ()]
		public void TestContinuationTaskAgain ()
		{
			var sut = new TaskExample ();
			var result = sut.ContinuationTaskAgain ();

			Assert.IsTrue (sut.IsSet);
			Assert.AreEqual ("OnlyOnRanToCompletion", result);
		}

		[Test ()]
		public void TestChildTasks ()
		{
			var sut = new TaskExample ();
			var result = sut.ChildTasks ();

			Assert.AreEqual (3, result);
		}

		[Test ()]
		public void TestTaskFactory ()
		{
			var sut = new TaskExample ();
			var result = sut.TaskFactory ();

			Assert.AreEqual (3, result);
		}

		[Test ()]
		public void TestWaitAll ()
		{
			var sut = new TaskExample ();
			var result = sut.WaitAll ();

			Assert.AreEqual (6, result);
		}

		[Test ()]
		public void TestWaitAny ()
		{
			var sut = new TaskExample ();
			var result = sut.WaitAny ();

			Assert.AreEqual (6, result);
		}

		[Test ()]
		public void TestWhenAll ()
		{
			var sut = new TaskExample ();
			var result = sut.WhenAll ();

			Assert.AreEqual (6, result);
		}

		[Test ()]
		public void TestTimingOutATask ()
		{
			var sut = new TaskExample ();
			var result = sut.TimingOutATask ();

			Assert.AreEqual (0, result);
		}

		[Test ()]
		public void TestCancellingATask ()
		{
			var sut = new TaskExample ();
			var result = sut.CancellingATask ();

			Assert.AreEqual (true, result);
		}
	}
}