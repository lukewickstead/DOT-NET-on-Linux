using NUnit.Framework;
using System;
using MultiThreading.Spawning;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class GetStringAsyncExampleTest
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new GetStringAsyncExample ();
			var result = sut.ReadAsyncHttpRequest ();

			Assert.IsTrue (result.Result.Contains ("google"));
		}

		[Test ()]
		public void TestCaseTwo ()
		{
			var sut = new GetStringAsyncExample ();
			var result = sut.ExecuteMultipleRequestsInParallel ();

			Assert.IsTrue (result.Result.Contains ("google"));
			Assert.IsTrue (result.Result.Contains ("monodevelop"));
		}
	}
}