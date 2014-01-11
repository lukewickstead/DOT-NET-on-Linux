using NUnit.Framework;
using System;
using System.Threading;
using TestingMoqingDebugging.Debugging;

namespace TestingMoqingDebugging.Debugging.Tests
{
	[TestFixture ()]
	public class EventLogSampleTests
	{
		[Test ()]
		public void TestSubscribe ()
		{
			var sut = new EventLogSample ();
			sut.Subscribe ();

			for (var x = 0; x < 10; x++) {
				if (sut.Hit)
					break;

				Thread.Sleep (100);
			}

			Assert.That (sut.Hit);
		}

		[Test ()]
		public void TestReadWrite ()
		{
			var sut = new EventLogSample ();
			sut.Write ();
			var foo = sut.Read ();
			Assert.IsTrue (foo.Contains ("The Message"));
		}
	}
}